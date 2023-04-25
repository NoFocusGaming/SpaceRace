using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartPhysics : MonoBehaviour
{
    public Cart cart;

    public Vector3 eulerRotation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
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
            cart.speed = cart.speed + cart.acceleration * Time.deltaTime;
        }else if(cart.speed > cart.desiredSpeed){
            cart.speed = cart.speed - cart.deacceleration * Time.deltaTime;
        }
        cart.speed = Utils.Clamp(cart.speed, cart.minSpeed, cart.maxSpeed);

        cart.velocity.x = Mathf.Cos(cart.heading * Mathf.Deg2Rad) * cart.speed;
        cart.velocity.y = 0;
        cart.velocity.z = Mathf.Sin(-cart.heading * Mathf.Deg2Rad) * cart.speed;

        cart.position = cart.position + cart.velocity * Time.deltaTime;
        transform.localPosition = cart.position;

        eulerRotation.y = cart.heading;
        transform.localEulerAngles = eulerRotation;
    }
}
