using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public string[] sentenceList;
    public TMP_Text message;

    public void Start()
    {
        StartCoroutine("en");
    }

    public IEnumerator en()
    {
        foreach(string sentence in sentenceList)
        {
            message.text = sentence;
            yield return new WaitForSeconds(10);
        }
    }

  
}
