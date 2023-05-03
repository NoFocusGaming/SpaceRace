using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMgr : MonoBehaviour
{
    public static UIMgr inst;
    private void Awake()
    {
        inst = this;
    }

    // text setting for placement
    public TextMeshProUGUI placeText;
    public TextMeshProUGUI lapText;

    public GameObject offRoadWarning;
    public GameObject instructions;

    public int maxLap;
    public int place;

    // image setting for held item

    public Image currItem;

    public List<Sprite> items;
    public int spriteIndex;

    // Start is called before the first frame update
    void Start()
    {
        place = 1;

        spriteIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(ControlMgr.inst.gameStart){
            instructions.SetActive(false);
        }

        switch (place)
        {
            case 1:
                placeText.SetText(place + "st!");
                break;
            case 2:
                placeText.SetText(place + "nd!");
                break;
            case 3:
                placeText.SetText(place + "rd!");
                break;
            default:
                placeText.SetText(place + "th!");
                break;
        }
        lapText.SetText(ControlMgr.inst.playerOne.currLap + "/" + maxLap);

        currItem.sprite = items[spriteIndex];
    }
}
