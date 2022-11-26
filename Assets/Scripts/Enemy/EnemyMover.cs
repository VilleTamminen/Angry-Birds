using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMover : MonoBehaviour
{
    public float speed = 5f;
    public float moveDistanceSideToSide = 40f;

    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, moveDistanceSideToSide), transform.position.y, transform.position.z);
        //transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, 4),  transform.position.z);
    }

    
}

    
