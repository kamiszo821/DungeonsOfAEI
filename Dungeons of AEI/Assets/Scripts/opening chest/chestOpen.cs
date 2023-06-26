using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/**
 * Script connected to the chest, allows player to oben and close chest
 */
public class chestOpen : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerObject;

    [SerializeField]
    private bool isopened = false;

    private bool openingNow = false;

    private void OnEnable()
    {
        if (isopened == true)
        {
            transform.Rotate(-90, 0, 0, Space.Self);
        }
    }

    //if player is close enough, closes or opens chest after clicking on it
    private void OnMouseDown()
    {
        if (Math.Abs(PlayerObject.transform.position.x - transform.position.x) < 1.5 && Math.Abs(PlayerObject.transform.position.z - transform.position.z) < 1.5)
        {
            if (openingNow == false)
            {
                if (isopened == false)
                    OpenChest(false);
                if (isopened == true)
                    OpenChest(true);
            }
        }
    }

    //Two methods below are responsible for chest fluent movement 
    private void OpenChest(bool opened)
    {
        StartCoroutine(openGate(opened));
    }
    IEnumerator openGate(bool opened)
    {
        openingNow = true;
        float rotationAmount = 0f;
        Quaternion startingRotation = transform.rotation;
        for (float x = 0f; x <= 90f; x++)
        {
            if (isopened == false)
            {
                rotationAmount = -x;
            }
            else
            {
                rotationAmount = x;
            }
            Quaternion rotation = Quaternion.Euler(startingRotation.eulerAngles.x + rotationAmount, startingRotation.eulerAngles.y, startingRotation.eulerAngles.z);
            transform.rotation = rotation;
            yield return new WaitForSeconds(0.01f);
        }
        if (isopened == false)
            isopened = true;
        else if (isopened == true)
            isopened = false;
        openingNow = false;
    }
}
