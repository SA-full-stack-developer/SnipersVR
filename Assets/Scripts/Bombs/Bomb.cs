using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    private float timeToDestroy = 1f;
    private bool bombFlag = false;

    private void Update()
    {
        if (bombFlag){
            timeToDestroy = timeToDestroy - Time.deltaTime;

            if (timeToDestroy <= 0)
            {
                bombFlag = false;
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            this.GetComponentInChildren<ParticleSystem>().Play();
            this.GetComponent<MeshRenderer>().enabled = false;

            bombFlag = true;
        }
    }
}
