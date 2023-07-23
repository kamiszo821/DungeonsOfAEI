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

    private string riddle1 = "Ba³wany! Zw¹ siê czarodziejami a to zwyk³e ba³wany! Mówi³em im kilka razy, nie dodaje siê cukru do magicznych eliksirów w celu poprawienia ich smaku! Cukier mo¿e zabiæ czarodziejskie w³aœciwoœci wywaru lub gorzej, zmieniæ je na inne.  Najtrudniej to zrozumieæ Gormanowi, zwyk³y adept magii a g³upszy ni¿ niewyedukowany wieœniak. Ba³wan, ba³wan, TRZY RAZY BA£WAN…";
    private string riddle2 = "Ktoœ chce abym zada³ zagadkê?\nLubiê zagadki, jestem w to dobry\nUwielbiam zmuszaæ innych do myœlenia\nChyba nikt nie rozwi¹¿e zagadki\nZawsze w nie wygrywam!\n\n\n Nie kazdy wie, leczczasami trzeba przeanalizowaæ zagadkê od góry do do³u.";
    private string riddle3 = "Matematyka? To dziedzina zarezerwowana wy³¹cznie dla czarowników, nikt inny nie rozwi¹¿e tej zagadki:\r\nRok temu, arcymag Magnus zamówi³ sprzêt alchemiczny do nowej sali laboratoryjnej dla m³odych czarowników. Ca³y sprzêt kosztowa³ 1000 z³ote monety. Ju¿ pierwszego dnia, m³odzi czarodzieje zepsuli kilka urz¹dzeñ, nale¿a³o wiêc zakupiæ dodatkowe narzêdzia, które kosztowa³y po³owê ceny sprzêtu kupionego poprzedniego dnia. Drugiego dnia, czarownicy wyrz¹dzili szkody warte po³owê tych wyrz¹dzonych trzeciego dnia. Trzeciego dnia przesadzili i szkody kosztowa³y arcymaga sumê tego ile wynios³y szkody z pierwszego i drugiego dnia. Magnus jednak cierpliwie zamawia³ nowy sprzêt. \r\nIle wyniós³ ³¹czny koszt sprzêtów oraz wszystkich napraw?\r\n";
    private string riddle4 = "Helltarionie, mój przyjacielu, przyjaŸniliœmy siê 2 lata, jednak poró¿ni³a nas 1 rzecz. Twoje ambicje by³y 3 razy wiêksze ni¿ moje. Mimo ¿e 5 razy odci¹ga³em Ciê od pomys³u stworzenia tej strasznej maszyny, Ty nie s³ucha³eœ...";
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
            answerFeedback.text = "Dobra odpowieŸ";
            activate();
            StartCoroutine(lowerObject());
        }
        else
        {
            answerFeedback.text = "To b³êdna odpowiedŸ";
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


