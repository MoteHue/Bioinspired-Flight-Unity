using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{
    public PlayerController playerController;

    public override void OnPointerDown(PointerEventData eventData) {
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData) {
        base.OnPointerUp(eventData);
    }
}