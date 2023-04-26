using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerOpen : MonoBehaviour
{
    private bool alreadyOpened = false;

    [SerializeField]
    private int gateID;

    private float beginPos;

    [SerializeField]
    private float endPos = 3;

    private void Awake()
    {
        beginPos = transform.position.z;
    }

    private void OnEnable()
    {
        OpeningWheel.sendinfoWheel += OpenGateStart;

    }
    private void OnDisable()
    {
        OpeningWheel.sendinfoWheel -= OpenGateStart;
    }



    private void OpenGateStart(int id)
    {
        if (!alreadyOpened && this.gateID == id)
            StartCoroutine(openGate());
    }

    IEnumerator openGate()
    {
        alreadyOpened = true;
        for (int y = 0; y < 10; y++)
        {
            transform.position += new Vector3(0f, 0.5f, 0f) * Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        while (transform.position.z >= beginPos - endPos)
        {
            transform.position += new Vector3(0f, 0f, -0.8f * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
