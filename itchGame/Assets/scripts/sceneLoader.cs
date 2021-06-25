using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void quit()
    {
        Application.Quit();
    }
    public void loadLevelSelect()
    {
        SceneManager.LoadScene("levelSelect");
    }
    public void loadMain()
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void load3()
    {
        SceneManager.LoadScene("level3");
    }
    public void load2()
    {
        SceneManager.LoadScene("level2");
    }
    public void load1()
    {
        SceneManager.LoadScene("level1");
    }
    public void loadTut()
    {
        SceneManager.LoadScene("tutorial");
    }

}
