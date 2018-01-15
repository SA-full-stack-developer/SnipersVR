using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisorTrigger : MonoBehaviour {
    [SerializeField]
    private GameObject player;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //player.GetComponent<PlayerMovement>().changeCameraAuxToShootCam();
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //player.GetComponent<PlayerMovement>().changeCameraAuxToCam();
        }
    }
}
