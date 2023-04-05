using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]
    private Texture2D image;

    void Update()
    {
        Screen.lockCursor = true;

    }

    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (image.width / 2);
        float yMin = (Screen.height / 2) - (image.height / 2);

        GUI.DrawTexture(new Rect(xMin, yMin, image.width, image.height), image);


    }

}
