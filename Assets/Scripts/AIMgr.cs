using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMgr : MonoBehaviour
{
    public List<GameObject> path;
    public Cart AIPlayer;

    public int currPathItem;

    public float maxPathVectorDist;
    public Vector3 pathPoint, diff;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(ControlMgr.inst.gameStart){
            MoveAlongPath();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        diff = point - AIPlayer.transform.position;
        AIPlayer.desiredHeading = Mathf.Atan2(-diff.z, diff.x) * Mathf.Rad2Deg;
        AIPlayer.desiredSpeed = AIPlayer.maxSpeed;
    }

    public void MoveAlongPath()
    {
        pathPoint = path[currPathItem].transform.position;
        MoveToPoint(pathPoint);

        if(diff.magnitude < maxPathVectorDist){
            currPathItem += 1;
            if(currPathItem == path.Count)
                currPathItem = 0;

            if(currPathItem == 2 || currPathItem == 3 || currPathItem == 4 ){
                AIPlayer.maxSpeed = AIPlayer.initMaxSpeed - 4;
            }else if(currPathItem == 10 || currPathItem == 11 || currPathItem == 12 ){
                AIPlayer.maxSpeed = AIPlayer.initMaxSpeed - 4;
            }else{
                AIPlayer.maxSpeed = AIPlayer.initMaxSpeed;
            }
        }
    }
}
