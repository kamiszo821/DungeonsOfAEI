using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Script attached to the gate, after getting a proper signal, gate will be opnened
 * Gate will be open UP in the Y axis
 */
public class OpenGateUp : MonoBehaviour
{
    [SerializeField]
    private bool isopened = false;

    private float beginPos;

    [SerializeField]
    private float endPos = 3; //to determine object final position

    [SerializeField]
    private int gateID; // Serialized field for the unique ID of the gate

    private void Awake()
    {
        beginPos = transform.position.y;
    }

    private void OnEnable()
    {
        OpeningWheel.sendinfoWheel += startOpeningGate;
    }
    private void OnDisable()
    {
        OpeningWheel.sendinfoWheel -= startOpeningGate;
    }

    //check gate id with trigger id
    private void startOpeningGate(int id)
    {
        if (!isopened && this.gateID == id)
            StartCoroutine(OpenGate());
    }

    //fluently open the gate
    IEnumerator OpenGate()
    {
        isopened = true;
        while (transform.position.y <= beginPos + endPos)
        {
            transform.position += new Vector3(0f, 0.8f, 0f) * Time.deltaTime;
            yield return new WaitForSeconds(0f);
        }

    }
}
