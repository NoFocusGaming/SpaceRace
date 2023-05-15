using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameObject cart;
    public float acceleration;
    public float deacceleration;
    public float turnRate;

    public float maxSpeed;
    public float minSpeed;

    public float radius;
    public float width;
    public float height;

    public int effectTimer, collisionTimer;
    public float boost;
    public float initMaxSpeed, initAccel, initTurnRate;
    public bool offRoad;

    public int currLap;
    public bool onFinishLine, onCP;

    public bool AI;
    public Vector3 diff;

    public List<float> checkpointTimes;
    public int currCheckpoint, prevCheckpoint, numCheckpoints;
    void Start()
    {
        initMaxSpeed = maxSpeed;
        initAccel = acceleration;
        initTurnRate = turnRate;
        currLap = 0;
        numCheckpoints = 42;

        checkpointTimes = Enumerable.Repeat(2000f, numCheckpoints).ToList();
    }

    public void MoveToPoint(Vector3 point)
    {
        diff = point - transform.position;
        desiredHeading = Mathf.Atan2(-diff.z, diff.x) * Mathf.Rad2Deg;
        desiredSpeed = maxSpeed;
    }
}
