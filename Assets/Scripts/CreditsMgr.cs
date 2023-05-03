using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMgr : MonoBehaviour
{
    public Animator animator;
    public SceneMgr sm;

    public void Over(string message)
    {
        if (message.Equals("animOver"))
        {
            sm.loadOut = true;
            sm.ending = true;
        }
    }
}
