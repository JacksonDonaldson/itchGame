using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holeMover : MonoBehaviour
{
    public Transform hole1;
    public Transform hole2;
    public Vector3 start2Pos;
    public Vector3 start3Pos;

    public float pullForce;

    private float normalSize;
    private Rigidbody2D rb;
    private movement move;
    private float defaultDrag = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        move = gameObject.GetComponent(typeof(movement)) as movement;
    }

    // Update is called once per frame
    void Update()
    {
        //if player is within 1.2 units of the hole, pull player towards the center of the hole. If player is within .5, start transition to next hole.
        if (Mathf.Abs(transform.position.x - hole1.position.x) < .5 && Mathf.Abs(transform.position.y - hole1.position.y) < .5)
        {
            moveToHole2();
        }
        if (Mathf.Abs(transform.position.x - hole1.position.x) < 1.2 && Mathf.Abs(transform.position.y - hole1.position.y) < 1.2)
        {
            //dosizemult
            rb.AddForce(new Vector2(-(transform.position.x - hole1.position.x), -(transform.position.y - hole1.position.y)).normalized * Time.deltaTime * pullForce);
        }


        if (Mathf.Abs(transform.position.x - hole2.position.x) < .5 && Mathf.Abs(transform.position.y - hole2.position.y) < .5)
        {
            moveToHole3();
        }
        if (Mathf.Abs(transform.position.x - hole2.position.x) < 1.2 && Mathf.Abs(transform.position.y - hole2.position.y) < 1.2)
        {
            //dosizemult
            rb.AddForce(new Vector2(-(transform.position.x - hole2.position.x), -(transform.position.y - hole2.position.y)).normalized * Time.deltaTime * pullForce);
        }



    }
    void moveToHole2()
    {
        print("moving to hole 2");
        rb.velocity = new Vector2(0, 0);
        transform.position = start2Pos;
        move.dashCount = 2;
    }
    void moveToHole3()
    {
        print("moving to hole 3");
        rb.velocity = new Vector2(0, 0);
        transform.position = start3Pos;
        move.dashCount = 2;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "sand")
        {
            rb.drag = defaultDrag * 2;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "sand")
        {
            rb.drag = defaultDrag;
        }
    }
}
