using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDownMackine : MonoBehaviour
{

    [SerializeField]
    private GameObject PlayerObject;

    [SerializeField]
    private GameObject effects;

    private bool animationActive = false;

    private bool animateOnlyOnce = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (Math.Abs(PlayerObject.transform.position.x - transform.position.x) < 1.5 && Math.Abs(PlayerObject.transform.position.z - transform.position.z) < 1.5)
        {
            if (animationActive == false)
            {
                animationActive = true;
                animate();
            }
        }
    }

    private void animate()
    {
        StartCoroutine(startRotating());
    }

    IEnumerator startRotating()
    {
        Quaternion startingRotation = transform.rotation;
        for (int x = 0; x <= 360; x++)
        {
            Quaternion rotation = Quaternion.Euler(startingRotation.eulerAngles.x + x, startingRotation.eulerAngles.y, startingRotation.eulerAngles.z);
            transform.rotation = rotation;
            yield return new WaitForSeconds(0.01f);

        }
        if (!animateOnlyOnce)
        {
            animationActive = false;
        }
        effects.active = false;

    }
}
