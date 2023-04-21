using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CoinPick : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerObject;

    public delegate void activateDelegate();
    public static event activateDelegate picked;

    private void activate()
    {
        if (picked != null)
        {
            picked();
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
