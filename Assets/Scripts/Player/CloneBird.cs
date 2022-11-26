using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneBird : MonoBehaviour
{
    public Transform firePoint;
    public GameObject ClonePrefab;
    private bool Multiplyed = false; //multiply only once

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && Multiplyed == false && GetComponent<SpringJoint2D>().enabled == false)
        {
            Shoot();
            Multiplyed = false;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(ClonePrefab, firePoint.position, firePoint.rotation);
        Multiplyed = true;
    }
}
