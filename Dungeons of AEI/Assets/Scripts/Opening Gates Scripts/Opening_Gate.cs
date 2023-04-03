using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening_Gate : MonoBehaviour
{
    [SerializeField]
    private bool isopened = false;

    private float beginPos;



    private void Awake()
    {
        beginPos = transform.position.y;
    }


    private void OnEnable()
    {
        Slab_Activator.sendinfo += startClosingGate;

    }
    private void OnDisable()
    {
        Slab_Activator.sendinfo -= startClosingGate;
    }

    private void startClosingGate()
    {
        if (isopened == false)
            StartCoroutine(closeGate());
    }

    IEnumerator closeGate()
    {

        isopened = true;
        Debug.Log(beginPos);
        while (transform.position.y >= beginPos - 3)
        {
            transform.position += new Vector3(0f, -0.8f, 0f) * Time.deltaTime;
            Debug.Log(transform.position);
            yield return new WaitForSeconds(0f);
        }

    }
}