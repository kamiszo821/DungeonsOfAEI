using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningWheel : MonoBehaviour
{

    public delegate void activateDelegate();
    public static event activateDelegate sendinfoWheel;


    [SerializeField]
    private GameObject PlayerObject;

    void activate()
    {
        if (sendinfoWheel != null)
        {
            sendinfoWheel();
        }
    }

    private void OnMouseDown()
    {
        if (Math.Abs(PlayerObject.transform.position.x - transform.position.x) < 1.5 && Math.Abs(PlayerObject.transform.position.z - transform.position.z) < 1.5)
        {
            activate();
            animate();
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

    }

}
