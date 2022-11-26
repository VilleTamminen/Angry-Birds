using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlay : MonoBehaviour
{
    public GameObject levelButtons;
    public GameObject mainButtons;

    void Start()
    {
        mainButtons.SetActive(true);
        levelButtons.SetActive(false);
    }
    public void LevelSelection()
    {
        levelButtons.SetActive(true);
        mainButtons.SetActive(false);
    }
}
