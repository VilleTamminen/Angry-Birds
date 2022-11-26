using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;
    public float health = 20f;
    public static int EnemiesAlive = 0; //tells if enemies are still alive or not. used by menus.
    private bool deathCheck = false;
    void Start()
    {
        EnemiesAlive++; //add one enemyAlive++. every enemy does this one time at start of level
    }

   void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.magnitude > 10) //if hit velocity is bigger than minimum requirement, decrease health
        {
            health -= col.relativeVelocity.magnitude;
        }
        if(health <= 0)
        {
            Die();
        }
    }
    private void OnBecameInvisible() //camera bounds
    {
        Die();         //if out of camera sight, die
    }
    void Die()
    {
        //Quaternion.identity = ignore rotation
        Instantiate(deathEffect, transform.position, Quaternion.identity);  //create particle effect on death
        if (deathCheck == false)
        {
            EnemiesAlive--;
            deathCheck = true; //only decrease EnemiesAlive by one
        }
        if(EnemiesAlive == 0) //win
        {
            Debug.Log("LEVEL COMPLETED!!!");
        }
        Destroy(gameObject);
    }
}
