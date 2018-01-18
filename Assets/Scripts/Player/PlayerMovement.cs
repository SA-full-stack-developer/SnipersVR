using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerMovement : MonoBehaviour {

    //CONFIG MANDOS OCULUS
    public SteamVR_TrackedObject mTrackedObject = null;
    public SteamVR_Controller.Device mDevice;

    //GameObjects
    public GameObject leftHand;
    private Transform pointToMoveSprite;

    //RAYCAST
    private RaycastHit hitFloor;
    private Vector3 fwd;

    private void Awake() {
        mTrackedObject = GetComponent<SteamVR_TrackedObject>();
        pointToMoveSprite = GameObject.Find("crosshair_go").transform;
    }

    private void Update() {
        mDevice = SteamVR_Controller.Input((int)mTrackedObject.index);

        fwd = leftHand.transform.TransformDirection(Vector3.forward); 

        //Stick hacia delante y colisiona con algo
        if (mDevice.GetAxis().y > 0.5f && Physics.Raycast(leftHand.transform.position, fwd, out hitFloor, 50)) {
            if (hitFloor.collider.CompareTag("Floor")) { //Ese algo es el suelo
                if (!pointToMoveSprite.GetComponent<SpriteRenderer>().enabled) //Si no se ve indicador
                    pointToMoveSprite.GetComponent<SpriteRenderer>().enabled = true; // Se activa

                pointToMoveSprite.position = new Vector3(hitFloor.point.x, hitFloor.point.y + 0.1f, hitFloor.point.z);
            } else { //Si no choca contra el suelo
                if (pointToMoveSprite.GetComponent<SpriteRenderer>().enabled) //Si esta activo el indicador
                    pointToMoveSprite.GetComponent<SpriteRenderer>().enabled = false;//se desactiva
            }
        } else {
            pointToMoveSprite.GetComponent<SpriteRenderer>().enabled = false;//se desactiva
        }
    }
}
