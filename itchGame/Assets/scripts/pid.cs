using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pid
{
    public float p;
    public float i;
    public float d;
    private float calcI = 0;
    private float prevP = 0;
    private System.DateTime prevTime;

    public pid(float p, float i, float d)
    {
        
        this.p = p;
        this.i = i;
        this.d = d;
        prevTime = System.DateTime.Now;


    }
    public float calculate(float difference, float dt)
    {
       
        if (dt == 0)
        {
            return difference * p;
        }


        float calcP = difference * p;

        calcI += (difference * dt);

        float calcD = d * ((difference - prevP) / dt);

        prevP = difference;

        prevTime = System.DateTime.Now;


        return calcP + i* calcI + calcD;

    }
}
