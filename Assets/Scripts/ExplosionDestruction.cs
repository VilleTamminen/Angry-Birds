using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestruction : MonoBehaviour
{
    //chck if collider is destructible -> destroy
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag.Contains("DD"))  //DD for destructible
        {
            Destroy(coll.gameObject);
        }
    }
}
