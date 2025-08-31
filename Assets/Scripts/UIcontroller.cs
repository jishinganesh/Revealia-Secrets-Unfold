using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public GameObject levelPanal;
    public GameObject gamePannel;
    public GameObject backButton;
    public GameObject gameOverpannel;
    // Start is called before the first frame update
    void Start()
    {
        levelPanal.SetActive(true);
        gamePannel.SetActive(false);
        backButton.SetActive(false);
        gameOverpannel.SetActive(false);

    }

    // Update is called once per frame
    public void Level()
    {
        levelPanal.SetActive(false);
        gamePannel.SetActive(true);
        backButton.SetActive(true);
        gameOverpannel.SetActive(false);
    }
    public void back()
    {
        levelPanal.SetActive(true);
        gamePannel.SetActive(false);
        backButton.SetActive(false);
        gameOverpannel.SetActive(false);
    }
}
