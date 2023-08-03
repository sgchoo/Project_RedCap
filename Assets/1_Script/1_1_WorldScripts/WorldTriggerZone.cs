using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTriggerZone : MonoBehaviour
{
    public GameObject storyUI;
    public GameObject tutorialUI;

    public GameObject tutoralObjs;

    public void stroyBtn()
    {
        storyUI.SetActive(false);
    }

    public void TutorialBtn()
    {
        tutorialUI.SetActive(false);
    }
}
