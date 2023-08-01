using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Slider loadingBar;
    public Text loadingText;
    public Text loadingPercentText;


    private void Start()
    {
        StartCoroutine(TransitionNextScene());
        StartCoroutine(SetText());
    }

    //비동기 씬 코루틴
    IEnumerator TransitionNextScene()
    {
        if (MainGameManager.isEnded == false)
        {
            AsyncOperation ao = SceneManager.LoadSceneAsync("MainScene");

            ao.allowSceneActivation = false;

            while (!ao.isDone)
            {
                loadingBar.value = ao.progress;
                loadingPercentText.text = (ao.progress * 100f).ToString() + "%";

                if (ao.progress >= 0.9f)
                {
                    //여기에 플레이어 엑티브 추가
                    MainGameManager.objs.SetActive(true);
                    ao.allowSceneActivation = true;
                }

                yield return null;
            }
        }

        else if (MainGameManager.isEnded == true)
        {
            AsyncOperation ao = SceneManager.LoadSceneAsync("EndingScene");

            ao.allowSceneActivation = false;

            while (!ao.isDone)
            {
                loadingBar.value = ao.progress;
                loadingPercentText.text = (ao.progress * 100f).ToString() + "%";

                if (ao.progress >= 0.9f)
                {
                    //여기에 플레이어 엑티브 추가
                    ao.allowSceneActivation = true;
                    MainGameManager.isEnded = true;
                }

                yield return null;
            }
        }
        
    }

    IEnumerator SetText()
    {
        loadingText.text = "";
        loadingText.text = "잠시만 기다려 주세요.";

        yield return new WaitForSeconds(2f);

        loadingText.text = "";
        loadingText.text = "잠시만 기다려 주세요..";

        yield return new WaitForSeconds(2f);

        loadingText.text = "";
        loadingText.text = "잠시만 기다려 주세요...";

        yield return new WaitForSeconds(2f);

        loadingText.text = "";
        loadingText.text = "잠시만 기다려 주세요....";
    }
}
