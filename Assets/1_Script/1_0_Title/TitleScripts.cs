using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScripts : MonoBehaviour
{
    public void ClickStart()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void ClickExit() 
    {
#if UNITY_EDITOR
UnityEditor.EditorApplication.isPlaying = false;
#else 
Application.Quit();
#endif 
        
    }

}
