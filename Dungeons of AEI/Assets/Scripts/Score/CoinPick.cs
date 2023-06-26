using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script for coins, sends info to scoreboard to increment the final score.
 */
public class CoinPick : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerObject;

    public delegate void activateDelegate();
    public static event activateDelegate picked;

    //send info and destroy the coin
    private void activate()
    {
        if (picked != null)
        {
            picked();
            Destroy(gameObject);
        }
    }

    //check if player is close enough to pick the coin
    private void OnMouseDown()
    {
        if (Math.Abs(PlayerObject.transform.position.x - transform.position.x) < 1.5 && Math.Abs(PlayerObject.transform.position.z - transform.position.z) < 1.5)
        {
            activate();
        }
    }
}
