using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{
    private Rigidbody2D rb; //bird's rigidbody
    
    public float MoveDown = 1500;
    public float MoveUp = 1500;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // up
        {
            BoostUp();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // down
        {
            BoostDown();
        }

       
    }

    void BoostDown()
    {
        rb.AddForce(Vector3.down * MoveDown);
        //Boost can be used only once
        
    }

    void BoostUp()
    {
        rb.AddForce(Vector3.up * MoveUp);
       
    }

   

}
