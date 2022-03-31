using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartButton()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
