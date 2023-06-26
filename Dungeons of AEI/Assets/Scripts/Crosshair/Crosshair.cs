using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Script connected to the crosshair, places it in the moddle of the screen and makes it visible
 */
public class Crosshair : MonoBehaviour
{
    [SerializeField]
    private Texture2D image;
    private Texture2D noImage;

    void Start()
    {
        Screen.lockCursor = true;
    }

    //places Crosshair directly in the middle of the screen 
    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (image.width / 2);
        float yMin = (Screen.height / 2) - (image.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, image.width, image.height), image);
    }

}
