using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening_Gate : MonoBehaviour
{
    [SerializeField]
    private bool isopened = false;

    private float beginPos;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // closeGate();
    }
    // Y: 0.35
    // Yk: -2.8

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
            transform.position += new Vector3(0f, -0.2f, 0f) * Time.deltaTime;
            yield return new WaitForSeconds(0f);
        }





    }
}
