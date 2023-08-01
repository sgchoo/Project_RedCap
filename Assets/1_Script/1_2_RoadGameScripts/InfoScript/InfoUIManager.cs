using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoUIManager : MonoBehaviour
{
    private void Awake()
    {
        MainGameManager.objs = GameObject.Find("Player");
        MainGameManager.objs.SetActive(false);
    }

    public void StartGameBtn()
    {
        switch (MainGameManager.doneCount)
        {
            case 0:
                SceneManager.LoadScene("RoadGameScene3x3");
                break;

            case 1:
                SceneManager.LoadScene("RoadGameScene4x4_1st");
                break;

            case 2:
                SceneManager.LoadScene("RoadGameScene4x4_2nd");
                break;
        }
    }
}
