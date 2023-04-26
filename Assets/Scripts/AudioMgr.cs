using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    public static AudioMgr inst;
    private void Awake()
    {
        inst = this;
    }

    public AudioSource offRoadWarning;
    public AudioSource rocketBoost;
    public AudioSource backgroundMusic;

}
