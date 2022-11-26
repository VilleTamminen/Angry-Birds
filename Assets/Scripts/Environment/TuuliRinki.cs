using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuuliRinki : MonoBehaviour
{
    //toimii tulli ja magneetti effectille
    public bool directionForward; //poispäin vai taaksepäin kohteesta 
    void Update()
    {
        if (directionForward == true) //eteenpäin
        {
            transform.position += transform.up * Time.deltaTime * 20f;
            StartCoroutine(Kill());
        }
        if (directionForward == false) //taaksepäin
        {
            transform.position -= transform.up * Time.deltaTime * 20f;
            StartCoroutine(Kill());
        }
    }
    IEnumerator Kill()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
