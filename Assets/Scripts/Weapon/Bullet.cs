using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField]
    int power;
    [SerializeField]
    int velocity;
    [SerializeField]
    int distance;
    [SerializeField]
    string[] typeBullet;

    private float timeToDestroy = 2.5f;

    private void Update() {
        timeToDestroy = timeToDestroy - Time.deltaTime;

        if (timeToDestroy <= 0) {
            PhotonNetwork.Destroy(this.gameObject);
        }
    }

    public int getVelocity() {
        return this.velocity;
    }

    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag != "Weapon" && col.gameObject.tag != "Bounce") {
            PhotonNetwork.Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Player") {
            col.gameObject.GetComponent<PhotonView>().RPC("QuitarSalud", PhotonTargets.All, 10);
        }
    }
}
