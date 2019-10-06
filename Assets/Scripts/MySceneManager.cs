using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MySceneManager : MonoBehaviour
{
    [SerializeField] private GameObject dieScreen;
    [SerializeField] private GameObject player;
    [SerializeField] private Text pointText;
    [SerializeField] private GameObject aboutBox;
    private bool loaded = false;
    [SerializeField] private TMP_Text text;
    private bool died;

    public int points = 0;

    public void FixedUpdate()
    {
        if (!died)
        {

        points++;
            if (text != null)
            {
        text.text = points + "";

            }
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
        died = false;
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadAbout()
    {
        if (loaded)
        {
            aboutBox.SetActive(false);
            loaded = false;
        }
        else
        {
            loaded = true;
            aboutBox.SetActive(true);
        }
    }

    public void Die()
    {
        player.SetActive(false);
        pointText.text = points.ToString();
        dieScreen.SetActive(true);
        died = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
