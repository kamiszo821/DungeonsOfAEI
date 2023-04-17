using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningWheel : MonoBehaviour
{

    public delegate void activateDelegate(int id);
    public static event activateDelegate sendinfoWheel;

    [SerializeField]
    private int gateID=0;

    [SerializeField]
    private GameObject PlayerObject;

    [SerializeField]
    private bool animateOnlyOnce = false;

    private bool animationActive = false;


    void activate()
    {
        if (sendinfoWheel != null)
        {
            sendinfoWheel(gateID);
        }
    }

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

    private void animate()
    {
        StartCoroutine(startRotating());
    }

    IEnumerator startRotating()
    {
        for (int x = 0; x <= 360; x++)
        {
            Quaternion rotation = Quaternion.Euler(x, 0, 0);
            transform.rotation = rotation;
            yield return new WaitForSeconds(0.01f);

        }
        if (!animateOnlyOnce)
        {
            animationActive = false;
        }

    }

}
