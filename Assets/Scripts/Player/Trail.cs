using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{

    public GameObject[] trails;
    int next = 0;
    private float timeToStop = 4f; //how long the trail can live
    private bool hasLaunched = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnTrail", 0.1f, 0.1f);
    }

    void spawnTrail()
    {
        //check if intack in spring joint and velocity is high enough
        if (this.GetComponent<SpringJoint2D>().enabled == false && GetComponent<Rigidbody2D>().velocity.sqrMagnitude > 25) 
        {
            Instantiate(trails[next], transform.position, Quaternion.identity);
            next = (next + 1) % trails.Length;

            if (hasLaunched == false) //do only once
            {
                StartCoroutine(Stop());
                hasLaunched = true;
            }
        }
    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(timeToStop);
        CancelInvoke(); //stop invokeRepeating
    }
}
