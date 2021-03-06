﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerMovement : MonoBehaviour {

    //CONFIG MANDOS OCULUS
    public SteamVR_TrackedObject mTrackedObject = null;
    public SteamVR_Controller.Device mDevice;

    //GameObjects
    public GameObject leftHand;
    public GameObject vrCamera;
    public GameObject body;

    private GameObject parentCamera;
    private Transform pointToMoveSprite;
    
    //RAYCAST
    private RaycastHit hitFloor;
    private Vector3 fwd;
    private Vector3 punto;

    //FLAGS
    private bool startMovement = false;
    private bool moving = false;

    private void Awake() {
        mTrackedObject = GetComponent<SteamVR_TrackedObject>();
        pointToMoveSprite = GameObject.Find("crosshair_go").transform;
        parentCamera = transform.parent.gameObject;
    }

    private void Update() {
        mDevice = SteamVR_Controller.Input((int)mTrackedObject.index);

        fwd = leftHand.transform.TransformDirection(Vector3.forward); 

        //Stick hacia delante y colisiona con algo
        if (mDevice.GetAxis().y > 0.5f && Physics.Raycast(leftHand.transform.position, fwd, out hitFloor, 50)) {
            if (hitFloor.collider.CompareTag("Floor")) { //Ese algo es el suelo
                if (!pointToMoveSprite.GetComponent<SpriteRenderer>().enabled) //Si no se ve indicador
                    pointToMoveSprite.GetComponent<SpriteRenderer>().enabled = true; // Se activa

                punto = new Vector3(hitFloor.point.x, body.transform.position.y, hitFloor.point.z);
                startMovement = true;

                pointToMoveSprite.position = new Vector3(hitFloor.point.x, hitFloor.point.y + 0.1f, hitFloor.point.z);
            } else { //Si no choca contra el suelo
                if (pointToMoveSprite.GetComponent<SpriteRenderer>().enabled) //Si esta activo el indicador
                    pointToMoveSprite.GetComponent<SpriteRenderer>().enabled = false;//se desactiva

                startMovement = false;
            }
        } else {
            pointToMoveSprite.GetComponent<SpriteRenderer>().enabled = false;//se desactiva

            if (startMovement) {
                startMovement = false;
                moving = true;
            }
        }

        if (moving) {
            move();
        }
    }

    private void move() {
        float step = 1 * Time.deltaTime;
        body.transform.position = Vector3.MoveTowards(body.transform.position, punto, step);

        if (body.transform.position.x == punto.x && body.transform.position.z == punto.z) {
            moving = false;
            vrCamera.transform.parent = parentCamera.transform;
            vrCamera.transform.localPosition = new Vector3(0, 0, -0.07f);
            vrCamera.transform.localEulerAngles = transform.forward;
        }
    }
}
