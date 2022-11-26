using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private bool boostUsed = false;
    

    public float speed = 3050;
    private Rigidbody2D rb; //bird's rigidbody
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && boostUsed == false)
        {
            // apply boost
            Boost();
        }

    }

    void Boost()
    {
        rb.AddForce(Vector3.right * speed);
        //Boost can be used only once
        boostUsed = true;
    }
}
