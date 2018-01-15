using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Photon.MonoBehaviour {
    [SerializeField]
    int bullets;
    [SerializeField]
    Transform shootSpawnPoint;
    /*[SerializeField]
    Transform shootSpawnPoint2;*/
    [SerializeField]
    Camera userCam;
    [SerializeField]
    Camera shooterCam;
    Camera[] camerasUser;

    private void Start() {
       /* camerasUser = player.GetComponents<Camera>();
        userCam = camerasUser[0];
        shooterCam = camerasUser[1];*/
    }

    // Update is called once per frame
    void Update () {
        if ((userCam.enabled || shooterCam.enabled) && photonView.isMine && Input.GetButtonDown("Fire1")) {
            shoot();
        }

        if ((userCam.enabled || shooterCam.enabled) && photonView.isMine && Input.GetButtonDown("Fire2")) {
            reloadWeapon();
        }
    }

    public void shoot() {
        if (bullets > 0) { 
            bullets -= 1;
            Transform shootSpawnPointFinal;
            Transform camTransform;

            shootSpawnPointFinal = shootSpawnPoint;
            if (userCam.enabled && shooterCam.enabled == false) {
                
                camTransform = userCam.transform;
            } else {
                //shootSpawnPointFinal = shootSpawnPoint2;
                camTransform = shooterCam.transform;
            }

            GameObject bulletProjectil = PhotonNetwork.Instantiate("Bullet", shootSpawnPointFinal.position, camTransform.rotation, 0);
            int velocidad = bulletProjectil.GetComponent<Bullet>().getVelocity();
            bulletProjectil.GetComponent<Rigidbody>().velocity = camTransform.TransformDirection(Vector3.forward * bulletProjectil.GetComponent<Bullet>().getVelocity());
        } else {
            Debug.Log("Sin balas, recargar");
        }
    }

    public void reloadWeapon() {
        bullets = 10;
    }
}
