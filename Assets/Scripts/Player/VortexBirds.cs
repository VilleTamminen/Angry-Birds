using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexBirds : MonoBehaviour
{
    float vortexStopTimer = 3.0f; //how long vortex is on
    private bool vortexTriggered = false;
    private Rigidbody2D rb;
    public GameObject VortexEffect;

    void Start()
    {
        GetComponent<PointEffector2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //if bird is out of slingshot, play vortex effect
        if (Input.GetButtonDown("Fire2") && vortexTriggered == false && GetComponent<SpringJoint2D>().enabled == false)
        {
            vortexTriggered = true;
            Vortex();
        }
    }

    public void Vortex()
    {
        //freeze movement
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        VortexEffect.SetActive(true);
        GetComponent<CircleCollider2D>().enabled = true; //circle collider is the area of push force
        GetComponent<PointEffector2D>().enabled = true;  //now it will pull objects with colliders 
        GetComponent<SpriteRenderer>().enabled = false; //hide sprite 1 (sleeping face)
        StartCoroutine(VortexStop());
    }
    
    IEnumerator VortexStop()
    {
        yield return new WaitForSeconds(vortexStopTimer);
        GetComponent<PointEffector2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        VortexEffect.SetActive(false);
    }
}
