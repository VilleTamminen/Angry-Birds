using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject bird;

    //Onko lingossa lintua
    bool occupied = true;

    private void Start()
    {
        Instantiate(bird, transform.position, Quaternion.identity);
    }
    void FixedUpdate()
        //Jos lingossa ei enää ole lintua, spawnaa uusi
    {
        if (occupied == false && sceneMoving() == false)
        {
            spawnNext();
          
        }
    }
    
    void spawnNext()
    //spawnaa uusi player
    {
        Instantiate(bird, transform.position, Quaternion.identity);
        occupied = true;
    }

    void OnTriggerExit2D(Collider2D co)
    //Player lähti spawn ympyrästä
    {
        occupied = false;
    }
    
    //Tarkistaa, että onko scenessä mitään liikkuvaa
    bool sceneMoving()
    {
        // Find all Rigidbodies, see if any is still moving a lot
        Rigidbody2D[] bodies = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
        foreach (Rigidbody2D rb in bodies)
            if (rb.velocity.sqrMagnitude > 5)
                return true;
        return false;
    }

}