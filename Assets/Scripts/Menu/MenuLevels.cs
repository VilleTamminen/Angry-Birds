using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevels : MonoBehaviour
{
    public GameObject levelButtons;
    public GameObject mainButtons;

    public int levelNumber = 0;  //back button will have number 0

    public void SelectLevel()
    {
        if (levelNumber == 0) //go back to first menu page
        {
            mainButtons.SetActive(true);
            levelButtons.SetActive(false);
        }
        else
        {
            //load level with LevelNumber
            SceneManager.LoadScene("Level_" + levelNumber, LoadSceneMode.Single);
        }
    }
}
