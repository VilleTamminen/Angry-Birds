using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnImpact : MonoBehaviour
{
    public float breakForce = 5000;
    float collisionForce(Collision2D coll)
    {
        // Estimate a collision's force (speed * mass)
        float speed = coll.relativeVelocity.sqrMagnitude;
        if (coll.collider.GetComponent<Rigidbody2D>())
            return speed * coll.collider.GetComponent<Rigidbody2D>().mass;
        return speed;    
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (collisionForce(coll) >= breakForce)
        {
            Destroy(gameObject);
        }
        else if (collisionForce(coll) >= 100)
        {
            breakForce -= collisionForce(coll); //weaken breakForce
        }
    }
}
