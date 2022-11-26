using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpactEffect : MonoBehaviour
{
    public GameObject impactEffect;
    //spawn particle effect on collision, then remove script


    private void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(this);
    }
}
