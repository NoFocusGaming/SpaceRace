using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    //-----------------------------
    // values that change while running
    //-----------------------------
    public Vector3 position = Vector3.zero;
    public Vector3 velocity = Vector3.zero;

    public float speed;
    public float desiredSpeed;
    public float heading;   // degrees
    public float desiredHeading; // degrees

    //-----------------------------
    // values that do not change
    //-----------------------------
    public float acceleration;
    public float deacceleration;
    public float turnRate;

    public float maxSpeed;
    public float minSpeed;

    // removed start & update functions, can be added back if we need them

    //for later
    /*
from: https://gamedevbeginner.com/input-in-unity-made-easy-complete-guide-to-the-new-system/
    for cart selection
        playerInput.SwitchCurrentActionMap("Menu");
    and the debug to check that it worked
        Debug.Log(playerInput.currentActionMap);

    camera setting is used for split-screen multiplayer (I forgot we'll need two cameras)

    Input.mousePosition is now Mouse.current.position.ReadValue()
        using UnityEngine.InputSystem

    now use input actions names to create functions - tack "On" to the start of the name of an action
    current:
        void OnTurnRight(){}
        void OnTurnLeft(){}
        void OnAccelerate(){}

     */
}
