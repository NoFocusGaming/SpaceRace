using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlMgr : MonoBehaviour
{
    public static ControlMgr inst;
    private void Awake()
    {
        inst = this;
    }

    public Cart playerOne;
    float deltaHeading;
    public float deltaSpeed;

    // Start is called before the first frame update
    void Start()
    {
        deltaHeading = playerOne.turnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
            Application.Quit();

        /*
        if(Input.GetKey(KeyCode.UpArrow))
            playerOne.desiredSpeed += deltaSpeed;
        else
            playerOne.desiredSpeed -= deltaSpeed;
       playerOne.desiredSpeed = Utils.Clamp(playerOne.desiredSpeed, playerOne.minSpeed, playerOne.maxSpeed);

        if(Input.GetKey(KeyCode.LeftArrow))
            playerOne.heading -= deltaHeading;
        if(Input.GetKey(KeyCode.RightArrow))
            playerOne.heading += deltaHeading;
        */
    }

    void OnTurnRight()
    {
        playerOne.heading += deltaHeading;
    }
    void OnTurnLeft()
    {
        playerOne.heading -= deltaHeading;
    }
    void OnAccelerate()
    {
        playerOne.desiredSpeed += deltaSpeed;
    }
}
