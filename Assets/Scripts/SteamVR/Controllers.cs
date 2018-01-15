using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllers : MonoBehaviour {
    private SteamVR_TrackedController _controller;
    private PrimitiveType _currentPrimitiveType = PrimitiveType.Sphere;

    private void OnEnable()
    {
        _controller = GetComponent<SteamVR_TrackedController>();
        //Pulsación Trigger
        _controller.TriggerClicked += HandleTriggerClicked;
        //Pulsación Joystick
        _controller.PadClicked += HandlePadClicked;
    }

    private void OnDisable()
    {
        _controller.TriggerClicked -= HandleTriggerClicked;
        _controller.PadClicked -= HandlePadClicked;
    }

    #region Shooting
    private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {
        this.GetComponentInChildren<Weapon>().shoot();
    }
    #endregion
    
    private void HandlePadClicked(object sender, ClickedEventArgs e)
    {
        this.GetComponentInChildren<Weapon>().reloadWeapon();
    }
}
