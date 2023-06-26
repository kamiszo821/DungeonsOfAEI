using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script attached to the opening slab, should open a chosen door after player
 * stand on it.
 */
public class Slab_Activator : MonoBehaviour
{

    private string PLAYER_TAG = "Player";

    public delegate void activateDelegate(int id);
    public static event activateDelegate sendinfo;

    [SerializeField]
    private int gateID = 0; //same as the doors that are about to be opened

    //detect collision with player
    public void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag(PLAYER_TAG))
        {

            activate();
        }
    }

    //send info to the chosen gate
    void activate()
    {
        if (sendinfo != null)
        {
            sendinfo(gateID);
        }
    }

}
