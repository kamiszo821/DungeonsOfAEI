using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//drag this script to Equipment object

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> spriteList = new List<Sprite>();
    // index - color
    // 0 - none
    // 1 - red
    // 2 - green
    // 3 - yellow

    [SerializeField]
    private GameObject slot1;
    [SerializeField]
    private GameObject slot2;
    [SerializeField]
    private GameObject slot3;

    private bool isRed = false;
    private bool isGreen = false;
    private bool isYellow = false;

    private int size = 0;


    private void OnEnable()
    {
        KeyPick.picked += gotKey;
    }

    private void OnDisable()
    {
        KeyPick.picked -= gotKey;
    }

    private void gotKey(string color)
    {
        switch (color)
        {
            case "red":
                {
                    isRed = true;
                    if (size == 0)
                        slot1.GetComponent<Image>().sprite = spriteList[1];
                    else if (size == 1)
                        slot2.GetComponent<Image>().sprite = spriteList[1];
                    else if (size == 2)
                        slot3.GetComponent<Image>().sprite = spriteList[1];
                    size++;
                    break;
                }
            case "green":
                {
                    isGreen = true;
                    if (size == 0)
                        slot1.GetComponent<Image>().sprite = spriteList[2];
                    else if (size == 1)
                        slot2.GetComponent<Image>().sprite = spriteList[2];
                    else if (size == 2)
                        slot3.GetComponent<Image>().sprite = spriteList[2];
                    size++;
                    break;
                }
            case "yellow":
                {
                    isYellow = true;
                    if (size == 0)
                        slot1.GetComponent<Image>().sprite = spriteList[3];
                    else if (size == 1)
                        slot2.GetComponent<Image>().sprite = spriteList[3];
                    else if (size == 2)
                        slot3.GetComponent<Image>().sprite = spriteList[3];
                    size++;
                    break;
                }
            default:
                Debug.LogError($"Unexpected color: {color}");
                break;
        }
    }




}


