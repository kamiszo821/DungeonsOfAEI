using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Simple main menu script, connected to main menu scene
 */
public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private string sceneName;
    public void Play()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
