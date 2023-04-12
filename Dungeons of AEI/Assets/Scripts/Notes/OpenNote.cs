using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;


public class OpenNote : MonoBehaviour
{
    [SerializeField]
    public Image noteImage;

    public GameObject hideNoteButton;

    public GameObject noteText;

    [SerializeField]
    private GameObject PlayerObject;
    // Start is called before the first frame update


    void Start()
    {
        noteImage.enabled = false;
        noteText.SetActive(false);
        hideNoteButton.SetActive(false);
    }


    public void ShowNoteImage()
    {
        FirstPersonController firstPersonController = PlayerObject.GetComponent<FirstPersonController>();
        Crosshair crosshair = PlayerObject.GetComponent<Crosshair>();
        noteImage.enabled = true;
        hideNoteButton.SetActive(true);
        noteText.SetActive(true);
        crosshair.enabled = false;
        Screen.lockCursor = false;
        firstPersonController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void HideNoteImage()
    {
        FirstPersonController firstPersonController = PlayerObject.GetComponent<FirstPersonController>();
        Crosshair crosshair = PlayerObject.GetComponent<Crosshair>();

        noteImage.enabled = false;
        firstPersonController.enabled = true;
        crosshair.enabled = true;
        hideNoteButton.SetActive(false);
        noteText.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void OnMouseDown()
    {
        if (Math.Abs(PlayerObject.transform.position.x - transform.position.x) < 1.5 && Math.Abs(PlayerObject.transform.position.z - transform.position.z) < 1.5)
        {
            ShowNoteImage();
            //Debug.Log("xd");
        }
    }
}


