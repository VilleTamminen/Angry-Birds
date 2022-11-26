using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFromLevels : MonoBehaviour
{
    public GameObject mainButtons; //hide buttons with SetActive
    public int levelNumber = 0;
    public bool pause = false;
    
    void Start()
    {
        Time.timeScale = 1f; 
        mainButtons.SetActive(false);
        pause = false;
    }
    public void SelectLevel() //select either: 1 = replay, 0 = menu, 2 = next level or 3 = quit
    {
        if (Enemy.EnemiesAlive == 0) //if there are no enemies alive, show menu
        {
            mainButtons.SetActive(true);
        }
        if (levelNumber == 0) //Menu
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
        if (levelNumber == 1) //replay this level
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (levelNumber == 2) //next level
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (levelNumber == 3)  //quit
        {
            Application.Quit();
        }
    }
    public void Pause() //pause and unpause game from top-left corner button
    {
        bool check = false;
        if (pause == false && check == false) //if pause was off, turn it on. PAUSE
        {
            pause = true;
            mainButtons.SetActive(true);
            Time.timeScale = 0.0000001f; //slow down time to near 0
            Debug.Log("pause on");
            check = true; //prevent another pause function
        }
        if (pause == true && check == false) //if pause was on, turn it off. UNPAUSE
        {
            pause = false;
            mainButtons.SetActive(false);
            Time.timeScale = 1f;
            Debug.Log("pause off");           
        }
        check = false;
    }

    void Update()
    {
        if (Enemy.EnemiesAlive == 0 || pause == true) //if there are no enemies alive, show menu
        {
            Time.timeScale = 0.0000001f;
            mainButtons.SetActive(true);
        }/*
        else if(Enemy.EnemiesAlive >= 1 && pause == false) //if there are enemies alive, hide menu 
        {
            mainButtons.SetActive(false);           
        }*/
    }
}
