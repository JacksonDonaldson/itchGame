using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dashUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] dashSprites;
    private movement m;
    public Image element;

    void Start()
    {
        m = gameObject.GetComponent(typeof(movement)) as movement;

    }

    // Update is called once per frame
    void Update()
    {
        int i = 2 * m.dashCount + m.collisions;
        element.sprite = dashSprites[i];

    }
}
