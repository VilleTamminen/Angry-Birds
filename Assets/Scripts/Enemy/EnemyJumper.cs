using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumper : MonoBehaviour
{
    Rigidbody2D enemyBody;
    public float jumpHeight = 650f;

    // Start is called before the first frame update
    void Start()
    {
        enemyBody = this.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "dirt")
        {
            enemyBody.velocity = new Vector2(0, 0);
            enemyBody.AddForce(Vector2.up * jumpHeight);
        }
    }
}
