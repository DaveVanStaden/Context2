using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingGame : MonoBehaviour
{
    private bool startEnding;
    private bool endScreen;
    private float timer;
    private float endTimer;
    public Image fadeImage;
    void Update()
    {
        if (startEnding)
        {
            var tempColor = fadeImage.color;
            if (tempColor.a <= 1)
            {
                timer += Time.deltaTime;
                if (timer >= 1)
                {
                    
                    tempColor.a += 0.1f;
                    fadeImage.color = tempColor;
                }
            }
            else
            {
                endScreen = true;
            }

            if (endScreen)
            {
                tempColor.a += 0.1f;
                fadeImage.color = tempColor;
                endTimer += Time.deltaTime;
                if (endTimer >= 2)
                {
                    Cursor.lockState = CursorLockMode.Confined;
                    SceneManager.LoadScene(sceneBuildIndex: 0);
                }
            }

        }
    }

    public void endGame()
    {
        startEnding = true;
    }
}
