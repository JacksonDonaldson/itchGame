using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Camera cam;
    public float power;
    
    private int maxDashes = 3;
    private Rigidbody2D rb;

    public int dashCount = 2;
    public int collisions;

    private AudioSource audioSource;
    public AudioClip dashSound;

    public bool holding;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        audioSource = gameObject.GetComponent(typeof(AudioSource)) as AudioSource;

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        doDash();

        deathCheck();

        
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
            
            

            if (dashCount > 0 && !holding)
            {
                audioSource.PlayOneShot(dashSound);
                dashCount--;
                rb.velocity = velocity;
            }
            holding = true;

        }
        else
        {
            holding = false;
        }
    }

    void deathCheck()
    {
        if (rb.velocity.x == 0 && rb.velocity.y == 0 && dashCount == 0)
        {
            print("dead");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (dashCount != maxDashes)
        {
            collisions++;
            if (collisions == 2)
            {
                dashCount++;
                collisions = 0;
            }
        }
    }
}
