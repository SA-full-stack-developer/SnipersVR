using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : MonoBehaviour {
    [SerializeField]
    Behaviour[] componentsToDisabled;
    [SerializeField]
    GameObject shootCamera;

    private void Start()
    {
    }
    
    private void OnDisable() {
    }

    //Desactivar todos los componentes del personaje que no se estén utilizando
    public void disabledAll() {
        for (int i = 0; i < componentsToDisabled.Length; i++) {
            //componentsToDisabled[i].enabled = false;
        }
    }

    //Habilitar todos los componentes del personaje que no se estén utilizando
    public void enabledAll() {
        for (int i = 0; i < componentsToDisabled.Length; i++) {
            componentsToDisabled[i].enabled = true;
        }
    }

    //TODO:
    public void enabledShootCamera() {
    }

    //TODO:
    public void enabledVRCamera()
    {
    }
}
