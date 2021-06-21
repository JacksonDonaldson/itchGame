using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LevelSelect()
    {
        SceneManager.LoadScene("levelSelect");
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
