using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expansion : MonoBehaviour
{
    //bird expands on contact
    public float GrowTime = 0.8f;
    public float expansionSpeed = 0.2f;
    private bool growing = false;
    private bool hasExpanded = false; // allows to grow only once
    public float waitToShrink = 2f;
    private bool shrink = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (growing == true && GetComponent<SpringJoint2D>().enabled == false && hasExpanded == false && shrink == false)  //grow slighty faster and then shrink. 
        {
            transform.localScale += new Vector3(expansionSpeed, expansionSpeed, 0); //growth speed       
            rb.mass = 8; //increase mass
        }
        else if (growing == false && GetComponent<SpringJoint2D>().enabled == false && hasExpanded == true && shrink == true)
        {
            transform.localScale -= new Vector3(expansionSpeed / 2, expansionSpeed / 2, 0); //shrink speed       
            rb.mass = 2; //increase mass
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (GetComponent<SpringJoint2D>().enabled == false && hasExpanded == false)
        {
            growing = true;
            StartCoroutine(TimeToGrow()); 
        }
    }
    IEnumerator TimeToGrow()
    {
        yield return new WaitForSeconds(GrowTime);
        growing = false;
        hasExpanded = true;
        StartCoroutine(TimeToShrink());
    }
    IEnumerator TimeToShrink()
    {
        yield return new WaitForSeconds(waitToShrink);
        StartCoroutine(Stop());
        shrink = true;
    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(GrowTime * 2);
        shrink = false;
    }
}
