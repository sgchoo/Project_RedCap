using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{

    public void ExitGameBtn()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MainGameManager.objs.SetActive(false);
        }
    }
}
