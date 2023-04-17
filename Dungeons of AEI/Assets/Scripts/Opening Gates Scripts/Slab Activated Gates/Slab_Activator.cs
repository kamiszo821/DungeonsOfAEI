using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slab_Activator : MonoBehaviour
{

    private string PLAYER_TAG = "Player";

    public delegate void activateDelegate(int id);
    public static event activateDelegate sendinfo;

    [SerializeField]
    private int gateID = 0;

    public void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag(PLAYER_TAG))
        {

            activate();
        }
    }


    void activate()
    {
        if (sendinfo != null)
        {
            sendinfo(gateID);
        }
    }

}
