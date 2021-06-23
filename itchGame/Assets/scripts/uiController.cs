using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] dashSprites;
    
    public Image element;
    public Text timer;
    public Text endTimer;
    public GameObject pausePanel;



    public float elapsedTime;

    private movement m;
    private bool hasClicked;
    private bool holdingPause;

    public GameObject endPanel;


    void Start()
    {
        m = gameObject.GetComponent(typeof(movement)) as movement;

    }

    // Update is called once per frame
    void Update()
    {
        checkPause();

        if(Input.GetAxis("Fire1") == 1)
        {
            hasClicked = true;
        }

        int i = 2 * m.dashCount + m.collisions;
        element.sprite = dashSprites[i];

        if (hasClicked)
        {
            elapsedTime += Time.deltaTime;
        }


        string timerText = ((int)elapsedTime / 60).ToString();
        timerText += ":";

        if (((int)elapsedTime % 60) < 10)
        {
            timerText += "0";
        }

        timerText += ((int)elapsedTime % 60).ToString();
        if ((elapsedTime - (int)elapsedTime).ToString().Length >= 4)
        {
            timerText += "." + (elapsedTime - (int)elapsedTime).ToString().Substring(2, 2);
        }
        
        timer.text = timerText;

    }

    void checkPause()
    {
        if (Input.GetAxisRaw("Pause") == 1)
        {
            print("buttoned");
            if (!holdingPause)
            {
                print("and not holding");
                holdingPause = true;
                if(Time.timeScale != 1)
                {
                    resume();
                }
                else
                {
                    pause();
                }
            }
        }
        else
        {
            holdingPause = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "endLevel")
        {
            openEndScreen();
        }
    }

    void openEndScreen()
    {
        endPanel.SetActive(true);
        timer.gameObject.SetActive(false);
        Time.timeScale = 0;
        endTimer.text = "Your Time: " + timer.text;

    }

    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("levelSelect");
    }

    public void pause()
    {
        print("pause");
        Time.timeScale = 0;
        pausePanel.SetActive(true);

    }
    public void resume()
    {
        print("resume");
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
