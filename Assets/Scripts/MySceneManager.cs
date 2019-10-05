using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MySceneManager : MonoBehaviour
{
    [SerializeField] private GameObject dieScreen;
    [SerializeField] private GameObject player;
    [SerializeField] private Text pointText;
    [SerializeField] private GameObject aboutBox;
    private bool loaded = false;

    public int points = 0;

    public void FixedUpdate()
    {
        points++;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(1);
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
    }
}
