using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Store_ctrl : MonoBehaviour
{
    public GameObject shopUI;
    public Camera cam;

    void Awake()
    {
        MainGameManager.objs = GameObject.Find("Player");
    }

    void OnMouseDown()
    {
        shopUI.SetActive(true);
        cam.gameObject.SetActive(true);
        MainGameManager.objs.SetActive(false);
    }

}
