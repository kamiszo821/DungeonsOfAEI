using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Script attached to the regular doors, player can open them with collision
 */
public class Opening_Door : MonoBehaviour
{
    [SerializeField]
    private bool isBlocked = false; //if false, player can open it with collison

    [SerializeField]
    private bool nextLevelDoor = false;

    [SerializeField]
    private string sceneName = "";


    private bool alreadyOpened = false;
    private string PLAYER_TAG = "Player";


    //Detect collision with player
    public void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag(PLAYER_TAG))
        {
            if (!isBlocked && !alreadyOpened)
                OpenGateStart();
        }
    }

    //fluently opens the door
    private void OpenGateStart()
    {
        StartCoroutine(openGate());
    }
    IEnumerator openGate()
    {
        alreadyOpened = true;
        if (nextLevelDoor)
            SceneManager.LoadScene(sceneName);
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
