using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("levelSelect");
    }

    public void tutorial()
    {
        SceneManager.LoadScene("tutorial");
    }

    public void level1()
    {
        SceneManager.LoadScene("level1");
    }

    public void level2()
    {
        SceneManager.LoadScene("level2");
    }

    public void level3()
    {
        SceneManager.LoadScene("level3");
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
