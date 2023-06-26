using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * This script is connected to some objects in the game, makes those object move
 * after getting info from another object, it is used in some parkour game elements.
 */
public class moveXaxis : MonoBehaviour
{
    private bool alreadyOpened = false;

    [SerializeField]
    private int gateID;
    private float beginPos;
    [SerializeField]
    private float endPos = 3;

    private void Awake()
    {
        beginPos = transform.position.x;
    }

    //getting info that object should move
    private void OnEnable()
    {
        OpeningWheel.sendinfoWheel += OpenGateStart;

    }
    private void OnDisable()
    {
        OpeningWheel.sendinfoWheel -= OpenGateStart;
    }

    //start fluently moving object
    private void OpenGateStart(int id)
    {
        if (!alreadyOpened && this.gateID == id)
            StartCoroutine(openGate());
    }

    IEnumerator openGate()
    {
        alreadyOpened = true;
        while (transform.position.x <= beginPos + endPos)
        {
            //changes object position
            transform.position += new Vector3(0.8f * Time.deltaTime, 0f, 0f);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
