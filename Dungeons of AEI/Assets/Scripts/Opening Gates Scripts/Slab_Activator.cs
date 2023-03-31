using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slab_Activator : MonoBehaviour
{
    // Start is called before the first frame update

    private string PLAYER_TAG = "Player";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("tak");
    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag(PLAYER_TAG))
        {
            Debug.Log("siema");
            activate();
        }
    }
    public delegate void activateDelegate();

    public static event activateDelegate sendinfo;

    void activate()
    {
        if (sendinfo != null)
        {
            sendinfo();
        }
    }

}
