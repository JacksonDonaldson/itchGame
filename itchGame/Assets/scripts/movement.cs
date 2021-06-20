using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Camera cam;
    public float power;
    private bool canDash = true;
    private Rigidbody2D rb;
    int collisions;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        
    }

    // Update is called once per frame
    void Update()
    {

        doDash();


        
    }

    void doDash()
    {
        //get distance from character to mouse pointer
        Vector3 point = new Vector3();
        Vector2 mousePos = new Vector2();
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
        float xVal = point.x - transform.position.x;
        float yVal = point.y - transform.position.y;

        //get velocty based on propotions of distance
        float xPow = xVal / (Mathf.Abs(xVal) + Mathf.Abs(yVal));
        float yPow = yVal / (Mathf.Abs(xVal) + Mathf.Abs(yVal));
        Vector2 velocity = new Vector2(xPow * power, yPow * power);

        //
        if (Input.GetAxis("Fire1") == 1)
        {
            if (canDash)
            {
                canDash = false;
                rb.velocity = velocity;
            }

        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (!canDash)
        {
            collisions++;
            if (collisions == 2)
            {
                canDash = true;
                collisions = 0;
            }
        }
    }
}
