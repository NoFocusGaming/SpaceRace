using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartPhysics : MonoBehaviour
{
    public Cart cart;
    private Rigidbody rbFR,rbFL,rbBR,rbBL;
    public GameObject wheelFR,wheelFL,wheelBR,wheelBL;

    public bool player;

    public Vector3 eulerRotation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rbFR = wheelFR.GetComponent<Rigidbody>();
        rbFL = wheelFL.GetComponent<Rigidbody>();
        rbBR = wheelBR.GetComponent<Rigidbody>();
        rbBL = wheelBL.GetComponent<Rigidbody>();
        cart.position = transform.localPosition;  
    }

    // Update is called once per frame
    void Update()
    {
        //------------------------------------
        // speed
        //------------------------------------
        if(Utils.ApproximatelyEqual(cart.speed, cart.desiredSpeed)){
            ;
        }else if(cart.speed < cart.desiredSpeed){
            cart.speed = cart.speed + cart.acceleration * cart.boost * Time.deltaTime;
        }else if(cart.speed > cart.desiredSpeed){
            cart.speed = cart.speed - cart.deacceleration * Time.deltaTime;
        }
        cart.speed = Utils.Clamp(cart.speed, cart.minSpeed, cart.maxSpeed);

        if(cart.AI){
            if(Utils.ApproximatelyEqual(cart.heading, cart.desiredHeading)){
                ;
            }else if(Utils.AngleDiffPosNeg(cart.desiredHeading, cart.heading) > 0){
                cart.heading += cart.turnRate * Time.deltaTime;
            }else if(Utils.AngleDiffPosNeg(cart.desiredHeading, cart.heading) < 0){
                cart.heading -= cart.turnRate * Time.deltaTime;
            }
        }
        
        cart.heading = Utils.Degrees360(cart.heading);

        cart.velocity.x = Mathf.Cos(cart.heading * Mathf.Deg2Rad) * cart.speed;
        cart.velocity.y = 0;
        cart.velocity.z = Mathf.Sin(-cart.heading * Mathf.Deg2Rad) * cart.speed;

        cart.position = cart.position + cart.velocity * Time.deltaTime;
        cart.transform.localPosition = cart.position;

        eulerRotation.y = cart.heading;
        cart.transform.localEulerAngles = eulerRotation;

        //----------------------
        // effects
        //----------------------
        if(cart.effectTimer > 0){
            cart.effectTimer -= 1;
            Debug.Log("Boosted");
        }else{
            cart.boost = 1;
            cart.maxSpeed = cart.initMaxSpeed;
        }
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        if(Physics.Raycast (cart.position, Vector3.down, out hit, Mathf.Infinity)){
            if(hit.collider.gameObject.CompareTag("FinishLine")){
                if(!cart.onFinishLine){
                    cart.currLap += 1;

                    cart.checkpointTimes[cart.currCheckpoint - 1] = Time.time;

                    cart.prevCheckpoint = cart.currCheckpoint;
                    cart.currCheckpoint += 1;
                    if(cart.currCheckpoint > cart.numCheckpoints)
                        cart.currCheckpoint = 1;

                    if(!cart.AI){
                        ControlMgr.inst.resetItems();
                }
                }
                cart.onFinishLine = true;
            }else if(hit.collider.gameObject.CompareTag("CP")){
                if(!cart.onCP){
                    cart.checkpointTimes[cart.currCheckpoint - 1] = Time.time;

                    cart.prevCheckpoint = cart.currCheckpoint;
                    cart.currCheckpoint += 1;
                    if(cart.currCheckpoint > cart.numCheckpoints)
                        cart.currCheckpoint = 1;
                }
                cart.onCP = true;
                cart.onFinishLine = false;
            }else{
                cart.onFinishLine = false;
                cart.onCP = false;
            } 
            
            if(hit.collider.gameObject.CompareTag("RoadCenter")){
                if(!cart.offRoad && player){
                    AudioMgr.inst.offRoadWarning.Play();
                    UIMgr.inst.offRoadWarning.SetActive(true);
                }
                cart.maxSpeed = 5;
                cart.offRoad = true;
            }else if(hit.collider.gameObject.CompareTag("Road")){
                if(cart.offRoad && player){
                    cart.maxSpeed = cart.initMaxSpeed;
                    AudioMgr.inst.offRoadWarning.Stop();
                    UIMgr.inst.offRoadWarning.SetActive(false);
                }
                cart.offRoad = false;
            }
        }else{
            if(!cart.offRoad && player){
                AudioMgr.inst.offRoadWarning.Play();
                UIMgr.inst.offRoadWarning.SetActive(true);
            }
            cart.maxSpeed = 5;
            cart.offRoad = true;
        }
    }
}
