using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;

public class Opening_DoorRiddle : MonoBehaviour
{
    [SerializeField]
    private bool isBlocked = true; //if false, player can open it with collison



    private bool alreadyOpened = false;
    private string PLAYER_TAG = "Player";

    [SerializeField]
    private int doorId;


    private void OnEnable()
    {

        OpenNoteAndUnlock.nowOpened += unlock;
    }

    private void OnDisable()
    {
        OpenNoteAndUnlock.nowOpened -= unlock;
    }

    private void unlock(int id)
    {
        if (doorId == id)
        {
            isBlocked = false;
        }
    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag(PLAYER_TAG))
        {
            if (!isBlocked && !alreadyOpened)
                OpenGateStart();

        }
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
