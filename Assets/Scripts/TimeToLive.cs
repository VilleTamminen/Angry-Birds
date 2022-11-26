using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour
{
    private float timeToLive = 4f;

    void Start()
    {
        StartCoroutine(TimeToDie());
    }

 IEnumerator TimeToDie()
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }
}
