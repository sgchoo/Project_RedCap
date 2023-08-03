using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowGameInfo : MonoBehaviour
{
    private void Awake()
    {
        MainGameManager.objs = GameObject.Find("Player");
        MainGameManager.objs.SetActive(false);
    }

    public void StartGameBtn()
    {
        SceneManager.LoadScene("ArrowGameScene");
    }
}
