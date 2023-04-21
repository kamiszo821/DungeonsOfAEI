using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Opening_doors : MonoBehaviour
{

    private bool isBlocked = true; //if false, player can open it with collison
    public delegate void activateDelegate(string color);
    public static event activateDelegate tryToOpen;
    private bool alreadyOpened = false;
    private string PLAYER_TAG = "Player";


    [SerializeField]
    private string color = " ";

    public void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag(PLAYER_TAG))
        {
            colidedWithDoors();
            if (!isBlocked && !alreadyOpened)
                OpenGateStart();

        }
    }

    private void colidedWithDoors()
    {
        if (tryToOpen != null)
        {
            tryToOpen(color);
        }
    }

    private void OnEnable()
    {
        InventoryController.sendBackInfo += unlock;
    }
    private void onDisable()
    {
        InventoryController.sendBackInfo -= unlock;
    }

    private void unlock(bool allow, string clr)
    {
        if (allow == true)
            if (clr == color)
                isBlocked = false;
    }
    private void OpenGateStart()
    {
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
