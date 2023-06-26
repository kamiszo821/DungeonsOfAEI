using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script attached to the opening wheel object. Makes a wheel rotating animation and
 * sends info to the chosen (by ID) object that should be opened eg. gate.
 */
public class OpeningWheel : MonoBehaviour
{
    public delegate void activateDelegate(int id);
    public static event activateDelegate sendinfoWheel;

    [SerializeField]
    private int gateID = 0; //should be the same as doors or gates that this wheel will open

    [SerializeField]
    private GameObject PlayerObject;

    [SerializeField]
    private bool animateOnlyOnce = false;

    private bool animationActive = false;

    //send info to open the chosen gate
    void activate()
    {
        if (sendinfoWheel != null)
        {
            sendinfoWheel(gateID);
        }
    }

    //check if the player is close enough to press this item
    private void OnMouseDown()
    {
        if (Math.Abs(PlayerObject.transform.position.x - transform.position.x) < 1.5 && Math.Abs(PlayerObject.transform.position.z - transform.position.z) < 1.5)
        {
            if (animationActive == false)
            {
                animationActive = true;
                activate();
                animate();
            }
        }
    }

    //fluent wheel rotating animation
    private void animate()
    {
        StartCoroutine(startRotating());
    }
    IEnumerator startRotating()
    {
        Quaternion startingRotation = transform.rotation;
        for (int x = 0; x <= 360; x++)
        {
            Quaternion rotation = Quaternion.Euler(startingRotation.eulerAngles.x + x, startingRotation.eulerAngles.y, startingRotation.eulerAngles.z);
            transform.rotation = rotation;
            yield return new WaitForSeconds(0.01f);

        }
        if (!animateOnlyOnce)
        {
            animationActive = false;
        }

    }

}
