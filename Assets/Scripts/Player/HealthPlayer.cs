using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour {

    private int salud = 30;

    [PunRPC]
    void QuitarSalud(int daño, PhotonMessageInfo info) {
        salud = salud - daño;

        if(salud <= 0) {
            PhotonNetwork.Destroy(this.gameObject);
        }
    }   
}
