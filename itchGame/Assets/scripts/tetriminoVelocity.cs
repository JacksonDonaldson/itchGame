using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetriminoVelocity : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = -2;
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rb.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, speed);
    }
}
