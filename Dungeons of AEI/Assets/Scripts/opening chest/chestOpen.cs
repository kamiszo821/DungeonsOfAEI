using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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

    private void OpenChest(bool opened)
    {
        StartCoroutine(openGate(opened));
    }

    IEnumerator openGate(bool opened)
    {
        openingNow = true;
        for (int x = 0; x <= 90; x++)
        {
            if (isopened == false)
                transform.Rotate(-1, 0, 0, Space.Self);
            if (isopened == true)
                transform.Rotate(1, 0, 0, Space.Self);
            yield return new WaitForSeconds(0.01f);
        }
        if (isopened == false)
            isopened = true;
        else if (isopened == true)
            isopened = false;
        openingNow = false;
    }
}
