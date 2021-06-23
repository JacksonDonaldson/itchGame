using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    public pid camSpeedPid;
    public float p = .08f;
    public float i = 0f;
    public float d = .001f;
    private Transform playerTransform;
    private Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        camSpeedPid = new pid(p,i,d);
        playerTransform = player.transform;
        playerRb = player.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camSpeedPid.p = p;
        camSpeedPid.i = i;
        camSpeedPid.d = d;

        float xDest = playerTransform.position.x;// + playerRb.velocity.x;
        float yDest = playerTransform.position.y;// + playerRb.velocity.y;

        float xDif = xDest - transform.position.x;
        float yDif = yDest - transform.position.y;
        float dif = Mathf.Sqrt(xDif * xDif + yDif * yDif);
        float camSpeed = camSpeedPid.calculate(dif, Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z), camSpeed);
    }
}
