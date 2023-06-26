using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script for the doors that should be opened after getting signal from
 * activation slab.
 */
public class Opening_Gate : MonoBehaviour
{
    [SerializeField]
    private bool isopened = false;

    [SerializeField]
    private float endPos = 3; //to determine object final position

    [SerializeField]
    private int gateID;

    private float beginPos;

    private void Awake()
    {
        beginPos = transform.position.y;
    }

    private void OnEnable()
    {
        Slab_Activator.sendinfo += startOpeningGate;

    }
    private void OnDisable()
    {
        Slab_Activator.sendinfo -= startOpeningGate;
    }

    //fluently open the gate
    private void startOpeningGate(int id)
    {
        if (!isopened && this.gateID == id)
            StartCoroutine(OpenGate());
    }
    IEnumerator OpenGate()
    {
        isopened = true;
        while (transform.position.y >= beginPos - endPos)
        {
            transform.position += new Vector3(0f, -0.8f, 0f) * Time.deltaTime;
            yield return new WaitForSeconds(0f);
        }

    }
}