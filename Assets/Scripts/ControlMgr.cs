using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMgr : MonoBehaviour
{
    public static ControlMgr inst;
    private void Awake()
    {
        inst = this;
    }

    public Cart playerOne;
    public List<Cart> cartsInPlay;
    public List<Rocket> rockets;
    float deltaHeading;
    public float deltaSpeed;
    public bool gameStart;

    public int winScene;

    // Start is called before the first frame update
    void Start()
    {
        deltaHeading = playerOne.turnRate;
    }

    private int currPlace;
    // Update is called once per frame
    void Update()
    {
        if(playerOne.currLap >= UIMgr.inst.maxLap){
            //win conditions loop
            Debug.Log("Race Finished");

            SceneManager.LoadScene(winScene, LoadSceneMode.Single);
        }

        if(!playerOne.onCP){
            currPlace = 1;
            foreach(Cart cart in cartsInPlay){
                if(cart.currLap > playerOne.currLap){
                    currPlace += 1;
                }else if(cart.currCheckpoint > playerOne.currCheckpoint){
                    currPlace += 1;
                }else if(cart.currCheckpoint == playerOne.currCheckpoint){
                    if(cart.checkpointTimes[cart.prevCheckpoint] < (playerOne.checkpointTimes[playerOne.prevCheckpoint] + 0.1))
                        currPlace += 1;
                }

                foreach (Rocket rocket in rockets){
                    if(Utils.collisionDetected(rocket.transform.localPosition, cart.position, rocket.radius, cart.radius)){
                        rocket.rocket.SetActive(false);
                        cart.effectTimer = 80;
                        cart.boost = rocket.speedMultiplier;
                        cart.maxSpeed += rocket.maxSpeedBoost;
                    }
                }
            }
            UIMgr.inst.place = currPlace;
        }

        if(playerOne.speed > 0){
            foreach (Rocket rocket in rockets){
                if(Utils.collisionDetected(rocket.transform.localPosition, playerOne.position, rocket.radius, playerOne.radius)){
                    AudioMgr.inst.rocketBoost.Play();
                    rocket.rocket.SetActive(false);
                    playerOne.effectTimer = 80;
                    playerOne.boost = rocket.speedMultiplier;
                    playerOne.maxSpeed += rocket.maxSpeedBoost;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();


        if (Input.GetKey(KeyCode.UpArrow)){
            playerOne.desiredSpeed += deltaSpeed;
            gameStart = true;
        }else{
            playerOne.desiredSpeed -= deltaSpeed;
        }
        playerOne.desiredSpeed = Utils.Clamp(playerOne.desiredSpeed, playerOne.minSpeed, playerOne.maxSpeed);

        if (Input.GetKey(KeyCode.LeftArrow))
            playerOne.heading -= deltaHeading;
        if(Input.GetKey(KeyCode.RightArrow))
            playerOne.heading += deltaHeading;
    }

    public void resetItems()
    {
        foreach(Rocket rocket in rockets)
            rocket.rocket.SetActive(true);
    }
}
