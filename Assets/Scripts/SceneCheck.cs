using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCheck : MonoBehaviour
{
   public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    } 

    public void PreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);

    }

    public void ChangeSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    public void TryAgain()
    {
        string lastScene = PlayerPrefs.GetString("LastScene", "DefaultScene");
        SceneManager.LoadScene(lastScene);
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
 }
