using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject rocket;  
    public float radius;
    public float speedMultiplier;
    public float maxSpeedBoost;

    private ControlMgr controlMgr;

    void Start()
    {
        controlMgr = ControlMgr.inst;
    }

    public void checkCollision()
    {
        if(Utils.collisionDetected(rocket.transform.localPosition, controlMgr.playerOne.position, radius, controlMgr.playerOne.radius)){
            AudioMgr.inst.rocketBoost.Play();
            rocket.SetActive(false);
            controlMgr.playerOne.effectTimer = 80;
            controlMgr.playerOne.boost = speedMultiplier;
            controlMgr.playerOne.maxSpeed += maxSpeedBoost;
        }
    }
}
