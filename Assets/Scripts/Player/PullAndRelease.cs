using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullAndRelease : MonoBehaviour
{
    public float force = 700;
    Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void OnMouseUp()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        Vector2 dir = startPos - (Vector2)transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir * force);

        // Remove the Script (not the gameObject)
        Destroy(this);
    }

    void OnMouseDrag()
    {
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Keep it in a certain radius
        float radius = 10f;
        Vector2 dir = p - startPos;
        if (dir.sqrMagnitude > radius)
            dir = dir.normalized * radius;

        // Set the Position
        transform.position = startPos + dir;
    }
}
