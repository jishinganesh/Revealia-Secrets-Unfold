using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void gameScene()
    {
        SceneManager.LoadScene("game");
    }
    public void backToMainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void quit()
    {
        Application.Quit();
    }
}
