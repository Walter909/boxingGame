using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void QuitButton()
    {

        Application.Quit();
        Debug.Log("Quit game");
    }

}
