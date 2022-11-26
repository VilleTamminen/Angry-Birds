using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedBirdLife : MonoBehaviour
{
    public Rigidbody2D rb; //clonebird's or poop's or whatever it is now.. rigidbody
    public float speed = 70f; //voima, jolla kloonattu/jakautunut/tai mikä nyt onkaan lintu lähtee liikkumaan
    //public float lifetime = 10f; //poop's time to live

    void Awake()
    {
        //Destroy(gameObject, lifetime);  //destroy clones
    }

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    
}
