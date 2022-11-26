using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuuletin : MonoBehaviour
{
    //toimii tuulettimella ja magneetilla
    public GameObject tuuli; //tuuli effect
    public Transform tr; //position, johon tuuli spawnataan
    public float Scale = 1.5f;

    void Start()
    {
        InvokeRepeating("spawnTuuli", 1f, 1f);
    }
    void spawnTuuli()
    {
        Instantiate(tuuli, tr.position, transform.rotation); //luo uusi tuuli 
        tuuli.transform.localScale = new Vector3(Scale, Scale, 1); //korjaa koko
    }
    
}
