using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;
using UnityEngine.UI;

/**
 * Script responcible to controll the key inventory, every cfollected key will be visible in the corner of the screen.
 * Keys will disappear after using them to open a proper door
 */
public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> spriteList = new List<Sprite>();
    // index - color
    // 0 - none
    // 1 - red
    // 2 - green
    // 3 - yellow

    //3 slots for 3 keys
    [SerializeField]
    private GameObject slot1;
    [SerializeField]
    private GameObject slot2;
    [SerializeField]
    private GameObject slot3;

    private bool isRed = false;
    private bool isGreen = false;
    private bool isYellow = false;
    private bool allowToOpen = false;

    private int redPos, greenPos, yellowPos;

    private int size = 0;

    public delegate void activateDelegate(bool allow, string color);
    //send info if we have a proper key
    public static event activateDelegate sendBackInfo;

    private AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        KeyPick.picked += gotKey;
        Key_Opening_doors.tryToOpen += sendKeyInfo;
    }

    private void OnDisable()
    {
        KeyPick.picked -= gotKey;
        Key_Opening_doors.tryToOpen -= sendKeyInfo;
    }

    /**
    *Method is being invoked after finding a key, checks the color, updates inventory info
    * and places key icon on the screen
    */
    private void gotKey(string color)
    {
        sound.Play();
        switch (color)
        {

            case "red":
                {
                    isRed = true;
                    if (size == 0)
                    {
                        slot1.GetComponent<Image>().sprite = spriteList[1];
                        redPos = 0;
                    }
                    else if (size == 1)
                    {
                        slot2.GetComponent<Image>().sprite = spriteList[1];
                        redPos = 1;
                    }
                    else if (size == 2)
                    {
                        slot3.GetComponent<Image>().sprite = spriteList[1];
                        redPos = 2;
                    }
                    size++;
                    break;
                }
            case "green":
                {
                    isGreen = true;
                    if (size == 0)
                    {
                        slot1.GetComponent<Image>().sprite = spriteList[2];
                        greenPos = 0;
                    }
                    else if (size == 1)
                    {
                        slot2.GetComponent<Image>().sprite = spriteList[2];
                        greenPos = 1;
                    }
                    else if (size == 2)
                    {
                        slot3.GetComponent<Image>().sprite = spriteList[2];
                        greenPos = 2;
                    }
                    size++;
                    break;
                }
            case "yellow":
                {
                    isYellow = true;
                    if (size == 0)
                    {
                        slot1.GetComponent<Image>().sprite = spriteList[3];
                        yellowPos = 0;
                    }
                    else if (size == 1)
                    {
                        slot2.GetComponent<Image>().sprite = spriteList[3];
                        yellowPos = 1;
                    }
                    else if (size == 2)
                    {
                        slot3.GetComponent<Image>().sprite = spriteList[3];
                        yellowPos = 2;
                    }
                    size++;
                    break;
                }
            default:
                Debug.LogError($"Unexpected color: {color}");
                break;
        }
    }

    /**
     * Method invoked after collision with a key requiring door, checks if we can open it
     */
    private void sendKeyInfo(string color)
    {
        if (color == "red")
        {
            if (isRed == true)
            {
                allowToOpen = true;
                reorder(redPos);
                isRed = false;
                sendResponse("red");

            }
        }
        if (color == "green")
        {
            {
                if (isGreen == true)
                {
                    allowToOpen = true;
                    reorder(greenPos);
                    isGreen = false;
                    sendResponse("green");
                }
            }
        }
        if (color == "yellow")
        {
            {
                if (isYellow == true)
                {
                    allowToOpen = true;
                    reorder(yellowPos);
                    isYellow = false;
                    sendResponse("yellow");
                }
            }
        }
    }

    //send response with key color
    private void sendResponse(string clr)
    {
        if (sendBackInfo != null)
        {
            sendBackInfo(allowToOpen, clr);
            allowToOpen = false;
        }
    }

    //replaces key icon with an empty image
    private void reorder(int pos)
    {
        if (pos == 0)
            slot1.GetComponent<Image>().sprite = spriteList[0];
        if (pos == 1)
            slot2.GetComponent<Image>().sprite = spriteList[0];
        if (pos == 2)
            slot3.GetComponent<Image>().sprite = spriteList[0];
    }


}


