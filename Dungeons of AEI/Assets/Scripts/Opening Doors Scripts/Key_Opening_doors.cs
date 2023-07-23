using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Script connected to color doors. If player has a proper key, doors will be opened
 */
public class Key_Opening_doors : MonoBehaviour
{

    private bool isBlocked = true; //if false, player can open it with collison

    public delegate void activateDelegate(string color);
    public static event activateDelegate tryToOpen;

    private bool alreadyOpened = false;
    private string PLAYER_TAG = "Player";

    [SerializeField]
    private string color = " ";

    private AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    //Detect collision with player
    public void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag(PLAYER_TAG))
        {
            colidedWithDoors();
            if (!isBlocked && !alreadyOpened)
                OpenGateStart();
        }
    }

    //try to open door after collision
    private void colidedWithDoors()
    {
        if (tryToOpen != null)
        {
            tryToOpen(color);
        }
    }

    //sends info to the equipment object to chech if player has a proper key
    private void OnEnable()
    {
        InventoryController.sendBackInfo += unlock;
    }
    private void onDisable()
    {
        InventoryController.sendBackInfo -= unlock;
    }

    //takes info from inventory object and unlocks the door if we have a proper key
    private void unlock(bool allow, string clr)
    {
        if (allow == true)
            if (clr == color)
                isBlocked = false;
    }

    //fluently opens the door
    private void OpenGateStart()
    {
        sound.Play();
        StartCoroutine(openGate());
    }
    IEnumerator openGate()
    {
        alreadyOpened = true;
        for (int x = 0; x <= 90; x++)
        {
            transform.Rotate(0, 1, 0, Space.Self);
            yield return new WaitForSeconds(0.01f);
        }
    }

    //fluently closes the door
    private void CloseGateStart()
    {

        StartCoroutine(closeGate());
    }

    IEnumerator closeGate()
    {
        alreadyOpened = false;
        for (int x = 0; x <= 90; x++)
        {
            transform.Rotate(0, -1, 0, Space.Self);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
