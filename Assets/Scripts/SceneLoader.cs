using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void loadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void loadCreditsScene()
    {
        SceneManager.LoadScene(7);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
