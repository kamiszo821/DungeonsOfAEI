using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using System.IO;


/**
 * Script connected to the Riddle, shows the text, has multiple control elements and provides
 * A visible interface for riddle solving player. 
 */
public class OpenNoteAndCheck : MonoBehaviour
{
    const string QUESTIONS_PATH = "Assets/Our Assets/Note Reading/Questions/";
    const string ANSWERS_PATH = "Assets/Our Assets/Note Reading/Answers/";

    //below all GUI element holders
    [SerializeField]
    public int noteID; // Serialized field for the unique ID of the note

    [SerializeField]
    public Image noteImage;

    [SerializeField]
    public Text userInput;

    [SerializeField]
    public Text answerFeedback;

    public GameObject hideNoteButton;

    [SerializeField]
    public GameObject noteText;

    [SerializeField]
    private GameObject PlayerObject;

    public GameObject submitButton;
    public GameObject userInputObject;
    public GameObject answerFeedbackObject;


    void Start()
    {
        if (null != noteImage)
        {
            noteImage.enabled = false;
        }
        if (null != noteText)
        {
            noteText.SetActive(false);
        }
        if (null != hideNoteButton)
        {
            hideNoteButton.SetActive(false);
        }
        if (null != userInputObject)
        {
            userInputObject.SetActive(false);
        }
        if (null != submitButton)
        {
            submitButton.SetActive(false);
        }
        if (null != answerFeedbackObject)
        {
            answerFeedbackObject.SetActive(false);
        }
    }


    //Show the riddle
    public void ShowNoteImage()
    {
        FirstPersonController firstPersonController = PlayerObject.GetComponent<FirstPersonController>();
        Crosshair crosshair = PlayerObject.GetComponent<Crosshair>();
        noteImage.enabled = true;
        hideNoteButton.SetActive(true);
        userInputObject.SetActive(true);
        submitButton.SetActive(true);
        noteText.SetActive(true);
        answerFeedbackObject.SetActive(true);
        Text uiText = noteText.GetComponent<Text>();

        //Read the text from directly from the file
        StreamReader reader = new StreamReader(QUESTIONS_PATH + noteID.ToString() + ".txt");
        uiText.text = reader.ReadToEnd();
        crosshair.enabled = false;
        Screen.lockCursor = false;
        firstPersonController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //Check if input answer is correct
    public void checkAnswer()
    {
        //Read the ANSWER from the file
        StreamReader reader = new StreamReader(ANSWERS_PATH + noteID.ToString() + ".txt");
        if (userInput.text == reader.ReadToEnd())
        {
            answerFeedback.text = "Correct!";
        }
        else
        {
            answerFeedback.text = "Wrong :(";
        }
    }

    //Hide the riddle
    public void HideNoteImage()
    {
        FirstPersonController firstPersonController = PlayerObject.GetComponent<FirstPersonController>();
        Crosshair crosshair = PlayerObject.GetComponent<Crosshair>();

        noteImage.enabled = false;
        firstPersonController.enabled = true;
        crosshair.enabled = true;
        hideNoteButton.SetActive(false);
        noteText.SetActive(false);
        userInputObject.SetActive(false);
        submitButton.SetActive(false);
        answerFeedbackObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    //Check if the player is close enough to open the riddle
    private void OnMouseDown()
    {
        if (Math.Abs(PlayerObject.transform.position.x - transform.position.x) < 1.5 && Math.Abs(PlayerObject.transform.position.z - transform.position.z) < 1.5)
        {
            ShowNoteImage();
        }
    }
}


