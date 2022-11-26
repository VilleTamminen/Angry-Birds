using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAnEgg : MonoBehaviour
{
    public float maxSpeed = 25f;
    public Rigidbody2D bullet;
    private Rigidbody2D rb; //bird's rigidbody
    private bool eggDropped = false; //drop egg only once
    private float thrust = 15000f; //voima, jolla lintu ammutaan, kun muna pudotetaan

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //bird's rigidbody
    }
    void Update()
    {
        //jos lintu on lähtenyt ritsasta ja pelaaja painaa hiiren oikeaa painiketta, tiputa muna
        if (Input.GetButtonDown("Fire2") && eggDropped == false && GetComponent<SpringJoint2D>().enabled == false)
        {
            DropEgg();
        }
    }

    void DropEgg()
    {
        //drop the egg
        Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
        bulletInstance.velocity = transform.forward * maxSpeed;
        Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //drop only once
        eggDropped = true;
        //shoot bird upwards
        rb.AddForce(transform.up * thrust); //shoot bird upwards
    }
}
