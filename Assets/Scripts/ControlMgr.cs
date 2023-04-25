using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMgr : MonoBehaviour
{
    public static ControlMgr inst;
    private void Awake()
    {
        inst = this;
    }

    public Cart playerOne;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float deltaSpeed;
    public float deltaHeading;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if(Input.GetKey(KeyCode.UpArrow))
            playerOne.desiredSpeed += deltaSpeed;
        else
            playerOne.desiredSpeed -= deltaSpeed;
       playerOne.desiredSpeed = Utils.Clamp(playerOne.desiredSpeed, playerOne.minSpeed, playerOne.maxSpeed);

        if(Input.GetKey(KeyCode.LeftArrow))
            playerOne.heading -= deltaHeading;
        if(Input.GetKey(KeyCode.RightArrow))
            playerOne.heading += deltaHeading;
    }
}
