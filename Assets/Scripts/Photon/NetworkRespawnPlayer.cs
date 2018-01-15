using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkRespawnPlayer : MonoBehaviour {
    [SerializeField]
    string version;
    [SerializeField]
    GameObject positionGroup1;
    [SerializeField]
    GameObject positionGroup2;
    [SerializeField]
    GameObject positionGroup3;

    GameObject player1;
    GameObject player2;
    GameObject player3;

    // Use this for initialization
    void Start() {
        PhotonNetwork.ConnectUsingSettings(version);
    }

    void OnJoinedLobby() {
        RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 3 };
        PhotonNetwork.JoinOrCreateRoom("Global", roomOptions, TypedLobby.Default);
    }

    private void Update() {
        //Cambiar a personaje 1
        if (Input.GetKeyDown("1")) {
            player1.GetComponent<PlayerSetup>().enabledAll();
            player2.GetComponent<PlayerSetup>().disabledAll();
            player3.GetComponent<PlayerSetup>().disabledAll();
        }

        //Cambiar a personaje 2
        if (Input.GetKeyDown("2")) {
            player1.GetComponent<PlayerSetup>().disabledAll();
            player2.GetComponent<PlayerSetup>().enabledAll();
            player3.GetComponent<PlayerSetup>().disabledAll();
        }

        //Cambiar a personaje 3
        if (Input.GetKeyDown("3")) {
            player1.GetComponent<PlayerSetup>().disabledAll();
            player2.GetComponent<PlayerSetup>().disabledAll();
            player3.GetComponent<PlayerSetup>().enabledAll();
        }

        //Cambiar a mira telescópica
        if (Input.GetKeyDown("4")) {
            if (player1.GetComponentsInChildren<Camera>()[0].enabled) {
            } else if (player2.GetComponentsInChildren<Camera>()[0].enabled) {
            } else if (player3.GetComponentsInChildren<Camera>()[0].enabled) {
            }
        }
    }

    private void OnJoinedRoom() {
        Transform[] positions;

        if (PhotonNetwork.otherPlayers.Length == 0) { //Somos los primeros en entrar al servidor
            positions = positionGroup1.GetComponentsInChildren<Transform>();
            player1 = PhotonNetwork.Instantiate("Player1", positions[1].transform.position, positions[0].transform.rotation, 0);
            player2 = PhotonNetwork.Instantiate("Player2", positions[2].transform.position, positions[1].transform.rotation, 0);
            player3 = PhotonNetwork.Instantiate("Player3", positions[3].transform.position, positions[2].transform.rotation, 0);
            player1.GetComponent<PlayerSetup>().enabledAll();
            player2.GetComponent<PlayerSetup>().disabledAll();
            player3.GetComponent<PlayerSetup>().disabledAll();
        }else if(PhotonNetwork.otherPlayers.Length == 1) {
            positions = positionGroup2.GetComponentsInChildren<Transform>();
            player1 = PhotonNetwork.Instantiate("Player1", positions[1].transform.position, positions[0].transform.rotation, 0);
            player2 = PhotonNetwork.Instantiate("Player2", positions[2].transform.position, positions[1].transform.rotation, 0);
            player3 = PhotonNetwork.Instantiate("Player3", positions[3].transform.position, positions[2].transform.rotation, 0);
            player1.GetComponent<PlayerSetup>().enabledAll();
            player2.GetComponent<PlayerSetup>().disabledAll();
            player3.GetComponent<PlayerSetup>().disabledAll();
        } else { //Si no lo somos
            positions = positionGroup3.GetComponentsInChildren<Transform>();
            player1 = PhotonNetwork.Instantiate("Player1", positions[1].transform.position, positions[0].transform.rotation, 0);
            player2 = PhotonNetwork.Instantiate("Player2", positions[2].transform.position, positions[1].transform.rotation, 0);
            player3 = PhotonNetwork.Instantiate("Player3", positions[3].transform.position, positions[2].transform.rotation, 0);
            player1.GetComponent<PlayerSetup>().enabledAll();
            player2.GetComponent<PlayerSetup>().disabledAll();
            player3.GetComponent<PlayerSetup>().disabledAll();
        }

    }
}
