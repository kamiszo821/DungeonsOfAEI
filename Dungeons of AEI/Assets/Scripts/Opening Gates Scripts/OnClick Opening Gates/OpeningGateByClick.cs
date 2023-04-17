using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningGateByClick : MonoBehaviour
{
    [SerializeField]
    private bool isopened = false;

    private float beginPos;

    [SerializeField]
    private float endPos = 3;

    [SerializeField]
    private int gateID; // Serialized field for the unique ID of the gate

    private void Awake()
    {
        beginPos = transform.position.y;
    }


    private void OnEnable()
    {
        OpeningWheel.sendinfoWheel += startClosingGate;

    }
    private void OnDisable()
    {
        OpeningWheel.sendinfoWheel -= startClosingGate;
    }

    private void startClosingGate(int id)
    {
        if (!isopened && this.gateID == id)
            StartCoroutine(closeGate());
    }

    IEnumerator closeGate()
    {

        isopened = true;
        while (transform.position.y >= beginPos - endPos)
        {
            transform.position += new Vector3(0f, -0.8f, 0f) * Time.deltaTime;
            yield return new WaitForSeconds(0f);
        }

    }
}
