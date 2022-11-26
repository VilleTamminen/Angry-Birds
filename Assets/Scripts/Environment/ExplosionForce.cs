using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForce : MonoBehaviour
{
    public float breakForce = 500; //breaks easily
    float explosionStopTimer = 0.3f;
    public GameObject Sprite;
    public GameObject Explosion;
    public GameObject ExplosionEffect;

    void Start()
    {
        ExplosionEffect.SetActive(false); //hide explopsion effect
        //remember to manually also switch these to unenabled in inspector!!!
        GetComponent<PointEffector2D>().enabled = false; //don't explode at start
        GetComponent<CircleCollider2D>().enabled = false; //circle collider is the area of push force
    } 
    float collisionForce(Collision2D coll) //calculate collision force
    {
        // Estimate a collision's force (speed * mass)
        float speed = coll.relativeVelocity.sqrMagnitude;
        if (coll.collider.GetComponent<Rigidbody2D>())
            return speed * coll.collider.GetComponent<Rigidbody2D>().mass;
        return speed;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (collisionForce(coll) >= breakForce) //break object
        {
            Explode(); //start explosion process
        }
    }
    void Explode()
    {

        GetComponent<PointEffector2D>().enabled = true;  //now it will push objects with colliders
        GetComponent<CircleCollider2D>().enabled = true; //circle collider is the area of push force
        ExplosionEffect.SetActive(true); //explosion 2d effect      
        Destroy(Sprite); //delete sprite
        StartCoroutine(ExplosionStop());
    }
    IEnumerator ExplosionStop()
    {
        yield return new WaitForSeconds(explosionStopTimer);
        GetComponent<PointEffector2D>().enabled = false; 
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(explosionStopTimer * 2); //wait until explosion animation is done
        Destroy(gameObject);
    }
}
