using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class levelSelectMedals : MonoBehaviour
{
    public Image L3;
    public Image L2;
    public Image L1;
    public Image Tut;

    public Sprite L3GoldSprite;
    public Sprite L3SilverSprite;
    public Sprite L3BronzeSprite;

    public Sprite L2GoldSprite;
    public Sprite L2SilverSprite;
    public Sprite L2BronzeSprite;

    public Sprite L1GoldSprite;
    public Sprite L1SilverSprite;
    public Sprite L1BronzeSprite;

    public Sprite TutGoldSprite;
    public Sprite TutSilverSprite;
    public Sprite TutBronzeSprite;

    public TMP_Text TutText;
    public TMP_Text L1Text;
    public TMP_Text L2Text;
    public TMP_Text L3Text;

    private float L3Gold = 16;
    private float L3Silver = 20;
    private float L3Bronze = 25;

    private float L2Gold;
    private float L2Silver;
    private float L2Bronze;

    private float L1Gold;
    private float L1Silver;
    private float L1Bronze;

    private float TutGold;
    private float TutSilver;
    private float TutBronze;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("L3"))
        {

            float l3Time = PlayerPrefs.GetFloat("L3");
            L3Text.text = "Best Time: " + strung(l3Time);

            if (l3Time < L3Gold)
            {
                L3.sprite = L3GoldSprite;
            }
            else if(l3Time < L3Silver)
            {
                L3.sprite = L3SilverSprite;
            }
            else if(l3Time < L3Bronze)
            {
                L3.sprite = L3BronzeSprite;
            }
        }

        if (PlayerPrefs.HasKey("L2"))
        {
            float l2Time = PlayerPrefs.GetFloat("L2");
            L2Text.text = "Best Time: " + strung(l2Time);

            if (l2Time < L2Gold)
            {
                L2.sprite = L2GoldSprite;
            }
            else if (l2Time < L2Silver)
            {
                L2.sprite = L2SilverSprite;
            }
            else if (l2Time < L2Bronze)
            {
                L2.sprite = L2BronzeSprite;
            }
        }

        if (PlayerPrefs.HasKey("L1"))
        {
            float l1Time = PlayerPrefs.GetFloat("L1");
            L1Text.text = "Best Time: " + strung(l1Time);

            if (l1Time < L1Gold)
            {
                L1.sprite = L1GoldSprite;
            }
            else if (l1Time < L1Silver)
            {
                L1.sprite = L1SilverSprite;
            }
            else if (l1Time < L1Bronze)
            {
                L1.sprite = L1BronzeSprite;
            }
        }

        if (PlayerPrefs.HasKey("Tut"))
        {
            float tutTime = PlayerPrefs.GetFloat("Tut");
            TutText.text = "Best Time: " + strung(tutTime);

            if (tutTime < TutGold)
            {
                Tut.sprite = TutGoldSprite;
            }
            else if (tutTime < TutSilver)
            {
                Tut.sprite = TutSilverSprite;
            }
            else if (tutTime < TutBronze)
            {
                Tut.sprite = TutBronzeSprite;
            }
        }

    }

    string strung(float time)
    {
        string toRet = ((int)time / 60).ToString();

        if (((int)time % 60) < 10)
        {
            toRet += "0";
        }

        toRet += ((int)time % 60).ToString();
        if ((time - (int)time).ToString().Length >= 4)
        {
            toRet += "." + (time - (int)time).ToString().Substring(2, 2);
        }
        return toRet;
    }
}
