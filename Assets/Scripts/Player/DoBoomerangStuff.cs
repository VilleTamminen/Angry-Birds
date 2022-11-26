using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoBoomerangStuff : MonoBehaviour
{
    private Rigidbody2D rb; //bird's rigidbody
    public float duration = 1; // in seconds

    public Rigidbody2D hook;
    public Vector3 beginPoint = new Vector3(0, 0, 0);
    public Vector3 finalPoint = new Vector3(0, 0, 30);
    public Vector3 farPoint = new Vector3(0, 0, 0);

    public bool startAgain = false;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (startAgain) Start();

        Vector3 center = (beginPoint + finalPoint) * 0.5F;
        center -= farPoint;

        Vector3 riseRelCenter = beginPoint - center;
        Vector3 setRelCenter = finalPoint - center;

        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, (Time.time - startTime) / duration);
        transform.position += center;
    }
}