using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    //code from Brackeys
    public Rigidbody2D rb;
    public Rigidbody2D hook;
    private bool isPressed = false;
    public float releaseTime = 0.15f;
    float maxDragDistance = 25f;
    public bool isFirstBall = false;

    public GameObject nextBall;   //nextBall is the ball that comes after this one. if it is last one then assign empty object to it.
    public GameObject previousBall; //previousBall is the ball that comes before this one. if it is first one then assign empty object to it.

    //Note that scene must have enemies so that you can use your bird/lingshot. Otherwise game thinks level is cleared.
    void Start()
    {
        if(isFirstBall == false && previousBall.activeInHierarchy == false) //make object inactive
        {
            gameObject.SetActive(false);
        }
         nextBall.SetActive(false);  //make next object inactive
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; //freeze rotation before ball is shot
    }
    void OnMouseDown()
    {
        if (Enemy.EnemiesAlive >= 1) //stop player if no enemies alive
        {
            isPressed = true;
            rb.isKinematic = true;
        }
    }
    void OnMouseUp()
    {
        if (Enemy.EnemiesAlive >= 1) //stop player if no enemies alive
        {
            isPressed = false;
            rb.isKinematic = false;
            rb.angularVelocity = 0; //stop rotation
            StartCoroutine(Release());
        }
    }

    void Update()
    {
        if (isFirstBall == false && previousBall.activeInHierarchy == false) //make object inactive
        {
            gameObject.SetActive(false);
        }
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //allow mouse to drag ball inside maxDragDistance, but not outside it
            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
            {
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            }
            else
            {
                rb.position = mousePos;
            }
        }
    }
    
    IEnumerator Release()  //release spring joint 2D after releaseTime and set next ball active
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false; //was changed to comment, not sure if needed 
        rb.constraints = RigidbodyConstraints2D.None; //set freeze rotation to none

        //get new ball
        yield return new WaitForSeconds(1f);
        if (nextBall != null)
        {
             nextBall.SetActive(true);
        }
        if (nextBall = null)
        { /*
            //game over, load level 
            Enemy.EnemiesAlive = 0;  //reset EnemiesAlive count
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); */
          //SceneManager.LoadScene(0); // loads the first level of game
          // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene("Menu");
        }
    }
}
