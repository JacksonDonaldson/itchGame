using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetriminator : MonoBehaviour
{
    public GameObject[] tetriminos;

    public float generationSpeed = .5f;
    private float lastTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastTime > generationSpeed)
        {
            lastTime = Time.time;
            generateTetrimino();
        }
    }

    void generateTetrimino()
    {
        Vector3 position = new Vector3(Random.Range(-3, 4), 5, 0);
        GameObject tetrimino = tetriminos[Random.Range(0, tetriminos.Length)];
        Instantiate(tetrimino, position, Quaternion.identity);
    }
}
