using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject leftHand;
    public Transform pointToMoveSprite;
    public GameObject vrCamera;
    //public OVRScreenFade screenFadeScript;
    public GameObject parentCamera;
    
    private bool moving = false;
    private Vector3 punto;
    private RaycastHit hitFloor;
    private Vector3 fwd;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update() {
        //Rayo de movimiento
        rayCastFloor();

        //Accion de moverse
        if (moving)
        {
            move();
        }
    }

    private void rayCastFloor()
    {
        //Preparamos colision y direccion del rayo
        fwd = leftHand.transform.TransformDirection(Vector3.forward);

        /*if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > 0 
            && Physics.Raycast(leftHand.transform.position, fwd, out hitFloor, 50) //Si colisiona con algo
            && hitFloor.collider.CompareTag("Floor"))
        {//Si es el suelo
            if (!pointToMoveSprite.GetComponent<SpriteRenderer>().enabled) //Si no se ve indicador
                pointToMoveSprite.GetComponent<SpriteRenderer>().enabled = true; // Se activa

            pointToMoveSprite.position = new Vector3(hitFloor.point.x, hitFloor.point.y + 0.1f, hitFloor.point.z);

            //Si se pulsa se inicia movimiento
            if (OVRInput.Get(OVRInput.Button.Four) == true && moving == false)
            {
                vrCamera.transform.parent = null;
                transform.LookAt(new Vector3(hitFloor.point.x, transform.position.y, hitFloor.point.z));
                punto = new Vector3(hitFloor.point.x, transform.position.y, hitFloor.point.z);
                moving = true;
            }
        }
        else
        { //Si no choca contra el suelo
            if (pointToMoveSprite.GetComponent<SpriteRenderer>().enabled) //Si esta activo el indicador
                pointToMoveSprite.GetComponent<SpriteRenderer>().enabled = false;//se desactiva
        }*/
    }

    private void move()
    {
        float step = 1 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, punto, step);

        if (transform.position.x == punto.x && transform.position.z == punto.z)
        {
            moving = false;
            //screenFadeScript.VisionOut();
            vrCamera.transform.parent = parentCamera.transform;
            vrCamera.transform.localPosition = new Vector3(0, 0, -0.07f);
            vrCamera.transform.localEulerAngles = transform.forward;
        }
    }
}
