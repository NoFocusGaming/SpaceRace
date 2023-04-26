using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMgr : MonoBehaviour
{
    public List<GameObject> path;
    public Cart AIPlayer;

    public int currPathItem;

    public float maxPathVectorDist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ControlMgr.inst.gameStart){
            AIPlayer.desiredSpeed = AIPlayer.maxSpeed;

            MoveOnPath();

            if(Utils.ApproximatelyEqual(AIPlayer.heading, AIPlayer.desiredHeading)){
                ;
            }else if(Utils.AngleDiffPosNeg(AIPlayer.desiredHeading, AIPlayer.heading) > 0){
                AIPlayer.heading += AIPlayer.turnRate * Time.deltaTime;
            }else if(Utils.AngleDiffPosNeg(AIPlayer.desiredHeading, AIPlayer.heading) < 0){
                AIPlayer.heading -= AIPlayer.turnRate * Time.deltaTime;
            }
        }
    }

    public void MoveOnPath()
    {
        Vector3 diff =  path[currPathItem].transform.position - AIPlayer.transform.position;
        AIPlayer.desiredHeading = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;

        if(diff.magnitude < maxPathVectorDist){
            currPathItem += 1;
            if(currPathItem == path.Count)
                currPathItem = 0;
        }
    }
}
