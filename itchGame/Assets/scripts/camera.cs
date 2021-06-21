using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform playerTransform;
    public pid camSpeedPid;
    public float p = .08f;
    public float i = 0f;
    public float d = .001f;


    // Start is called before the first frame update
    void Start()
    {
        camSpeedPid = new pid(p,i,d);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camSpeedPid.p = p;
        camSpeedPid.i = i;
        camSpeedPid.d = d;

        float xDif = playerTransform.position.x - transform.position.x;
        float yDif = playerTransform.position.y - transform.position.y;
        float dif = Mathf.Sqrt(xDif * xDif + yDif * yDif);
        float camSpeed = camSpeedPid.calculate(dif, Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z), camSpeed);
    }
}
