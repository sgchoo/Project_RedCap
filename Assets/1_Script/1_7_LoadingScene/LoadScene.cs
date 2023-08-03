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

    //�񵿱� �� �ڷ�ƾ
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
                    //���⿡ �÷��̾� ��Ƽ�� �߰�
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
                    //���⿡ �÷��̾� ��Ƽ�� �߰�
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
        loadingText.text = "��ø� ��ٷ� �ּ���.";

        yield return new WaitForSeconds(2f);

        loadingText.text = "";
        loadingText.text = "��ø� ��ٷ� �ּ���..";

        yield return new WaitForSeconds(2f);

        loadingText.text = "";
        loadingText.text = "��ø� ��ٷ� �ּ���...";

        yield return new WaitForSeconds(2f);

        loadingText.text = "";
        loadingText.text = "��ø� ��ٷ� �ּ���....";
    }
}
