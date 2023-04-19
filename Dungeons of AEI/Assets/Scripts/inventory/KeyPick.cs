using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class KeyPick : MonoBehaviour
{
    [SerializeField]
    private string keyColor = " ";

    [SerializeField]
    private GameObject PlayerObject;

    public delegate void activateDelegate(string color);
    public static event activateDelegate picked;

    private void activate()
    {
        if (picked != null)
        {

            picked(keyColor);
            Destroy(gameObject);
        }
    }
    private void OnMouseDown()
    {
        if (Math.Abs(PlayerObject.transform.position.x - transform.position.x) < 1.5 && Math.Abs(PlayerObject.transform.position.z - transform.position.z) < 1.5)
        {
            activate();
        }
    }
}
