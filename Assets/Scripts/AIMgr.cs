using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMgr : MonoBehaviour
{
    private List<GameObject> currPath;
    public List<GameObject> path;
    public List<GameObject> path1;
    public List<GameObject> path2;
    public List<Cart> AIPlayers;

    public List<int> currPathItem;
    public int currPathIndex;

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

    public void MoveAlongPath()
    {
        int index = 0;
        foreach(Cart cart in AIPlayers){
            currPathIndex = index;
            setCurrPath();
            pathPoint = currPath[currPathItem[index]].transform.position;
            cart.MoveToPoint(pathPoint);
            diff = pathPoint - cart.transform.position;

            if(diff.magnitude < maxPathVectorDist){
                currPathItem[index] += 1;
                if(currPathItem[index] == path.Count)
                    currPathItem[index] = 0;

                if(currPathItem[index] == 2 || currPathItem[index] == 3 || currPathItem[index] == 4 ){
                    cart.maxSpeed = cart.initMaxSpeed - 4;
                }else if(currPathItem[index] == 10 || currPathItem[index] == 11 || currPathItem[index] == 12 ){
                    cart.maxSpeed = cart.initMaxSpeed - 4;
                }else{
                    cart.maxSpeed = cart.initMaxSpeed;
                }
            }
            
            index++;
        }
    }

    public void setCurrPath(){
        if(currPathIndex == 0){
            currPath = path;
        }else if(currPathIndex == 1){
            currPath = path1;
        }else if(currPathIndex == 2){
            currPath = path2;
        }
    }
}
