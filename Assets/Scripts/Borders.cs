using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D co)
    {
        Destroy(co.gameObject);
    }
}
