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

    public float radius;

    public int effectTimer;
    public float boost;
    public float initMaxSpeed;
    public bool offRoad;

    public int currLap;
    public bool onFinishLine;

    void Start()
    {
        initMaxSpeed = maxSpeed;
        currLap = 0;
    }
}
