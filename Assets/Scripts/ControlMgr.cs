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

    // Update is called once per frame
    void Update()
    {
        if(playerOne.currLap >= UIMgr.inst.maxLap){
            //win conditions loop
            Debug.Log("Race Finished");

            SceneManager.LoadScene(winScene, LoadSceneMode.Single);
        }

        if(playerOne.speed > 0){
            foreach (Rocket rocket in rockets)
                rocket.checkCollision();
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
}
