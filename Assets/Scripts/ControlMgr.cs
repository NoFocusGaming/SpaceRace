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

    public bool gameWon;

    // Start is called before the first frame update
    void Start()
    {
        deltaHeading = playerOne.turnRate;
    }

    private int currPlace;
    // Update is called once per frame
    void Update()
    {
        if(playerOne.currLap > UIMgr.inst.maxLap){
            //win conditions loop
            Debug.Log("Race Finished");
            updatePlace();
            gameWon = true;

            if(UIMgr.inst.place == 1)
                SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
            else
                SceneManager.LoadScene("LoseScreen", LoadSceneMode.Single);
        }

        if(!playerOne.onCP){
            updatePlace();
        }

        if(playerOne.speed > 0){
            foreach (Rocket rocket in rockets){
                if(Utils.rocketCollisionDetected(rocket.transform.localPosition, playerOne.position, rocket.radius, playerOne.radius)){
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

    public void updatePlace()
    {
        currPlace = 1;
        foreach(Cart cart in cartsInPlay){
            if(cart.currLap > playerOne.currLap){
                currPlace += 1;
            }else if(cart.currLap == playerOne.currLap){
                if(cart.currCheckpoint > playerOne.currCheckpoint){
                    currPlace += 1;
                }else if(cart.currCheckpoint == playerOne.currCheckpoint){
                    if(cart.checkpointTimes[cart.prevCheckpoint - 1] < (playerOne.checkpointTimes[playerOne.prevCheckpoint - 1]))
                        currPlace += 1;
                }
            }
        }
        UIMgr.inst.place = currPlace;
    }

    public void resetItems()
    {
        foreach(Rocket rocket in rockets)
            rocket.rocket.SetActive(true);
    }
}
