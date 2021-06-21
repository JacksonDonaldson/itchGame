using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceSounds : MonoBehaviour
{
    private Rigidbody2D rb;
    public AudioClip[] bounces;
    private AudioSource audioSource;

    void Start()
    {
        rb = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        audioSource = gameObject.GetComponent(typeof(AudioSource)) as AudioSource;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        float vel = rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y;
        vel = Mathf.Sqrt(vel);
        vel = Mathf.Min(vel/7, 1);


        audioSource.PlayOneShot(bounces[Random.Range(0, bounces.Length)], vel);

    }


}
