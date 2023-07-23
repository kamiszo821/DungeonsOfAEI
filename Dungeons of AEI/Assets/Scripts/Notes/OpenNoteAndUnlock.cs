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
 * A visible interface for riddle solving player. This script also provides animation for the riddle
 * attached object.
 */
public class OpenNoteAndUnlock : MonoBehaviour
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
    public int riddleNumber;

    [SerializeField]
    private GameObject PlayerObject;

    public GameObject submitButton;

    public GameObject userInputObject;

    public GameObject answerFeedbackObject;

    public delegate void activateDelegate(int id);
    public static event activateDelegate nowOpened;

    private string riddle1 = "Ba�wany! Zw� si� czarodziejami a to zwyk�e ba�wany! M�wi�em im kilka razy, nie dodaje si� cukru do magicznych eliksir�w w celu poprawienia ich smaku! Cukier mo�e zabi� czarodziejskie w�a�ciwo�ci wywaru lub gorzej, zmieni� je na inne.  Najtrudniej to zrozumie� Gormanowi, zwyk�y adept magii a g�upszy ni� niewyedukowany wie�niak. Ba�wan, ba�wan, TRZY RAZY BA�WAN�";
    private string riddle2 = "Kto� chce abym zada� zagadk�?\nLubi� zagadki, jestem w to dobry\nUwielbiam zmusza� innych do my�lenia\nChyba nikt nie rozwi��e zagadki\nZawsze w nie wygrywam!\n\n\n Nie kazdy wie, leczczasami trzeba przeanalizowa� zagadk� od g�ry do do�u.";
    private string riddle3 = "Matematyka? To dziedzina zarezerwowana wy��cznie dla czarownik�w, nikt inny nie rozwi��e tej zagadki:\r\nRok temu, arcymag Magnus zam�wi� sprz�t alchemiczny do nowej sali laboratoryjnej dla m�odych czarownik�w. Ca�y sprz�t kosztowa� 1000 z�ote monety. Ju� pierwszego dnia, m�odzi czarodzieje zepsuli kilka urz�dze�, nale�a�o wi�c zakupi� dodatkowe narz�dzia, kt�re kosztowa�y po�ow� ceny sprz�tu kupionego poprzedniego dnia. Drugiego dnia, czarownicy wyrz�dzili szkody warte po�ow� tych wyrz�dzonych trzeciego dnia. Trzeciego dnia przesadzili i szkody kosztowa�y arcymaga sum� tego ile wynios�y szkody z pierwszego i drugiego dnia. Magnus jednak cierpliwie zamawia� nowy sprz�t. \r\nIle wyni�s� ��czny koszt sprz�t�w oraz wszystkich napraw?\r\n";
    private string riddle4 = "Helltarionie, m�j przyjacielu, przyja�nili�my si� 2 lata, jednak por�ni�a nas 1 rzecz. Twoje ambicje by�y 3 razy wi�ksze ni� moje. Mimo �e 5 razy odci�ga�em Ci� od pomys�u stworzenia tej strasznej maszyny, Ty nie s�ucha�e�...";
    private string answer1 = "888";
    private string answer2 = "klucz";
    private string answer3 = "3000";
    private string answer4 = "2135";

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

    void activate()
    {
        if (null != noteImage)
        {
            nowOpened(noteID);
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

        switch (riddleNumber)
        {
            case 1:
                uiText.text = riddle1;
                break;
            case 2:
                uiText.text = riddle2;
                break;
            case 3:
                uiText.text = riddle3;
                break;
            case 4:
                uiText.text = riddle4;
                break;
        }

        // StreamReader reader = new StreamReader(QUESTIONS_PATH + noteID.ToString() + ".txt");
        // uiText.text = reader.ReadToEnd();
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
        // StreamReader reader = new StreamReader(ANSWERS_PATH + noteID.ToString() + ".txt");
        string answer = "";

        switch (riddleNumber)
        {
            case 1:
                answer = answer1;
                break;
            case 2:
                answer = answer2;
                break;
            case 3:
                answer = answer3;
                break;
            case 4:
                answer = answer4;
                break;
        }
        if (userInput.text == answer)
        {
            answerFeedback.text = "Dobra odpowie�";
            activate();
            StartCoroutine(lowerObject());
        }
        else
        {
            answerFeedback.text = "To b��dna odpowied�";
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

    //lower riddle attached object on scene
    private IEnumerator lowerObject()
    {
        for (int x = 0; x < 1000; x++)
        {
            transform.position += new Vector3(0, -0.01f, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}


