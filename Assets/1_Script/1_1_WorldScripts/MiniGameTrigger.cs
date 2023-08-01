using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameTrigger : MonoBehaviour
{
    public Button[] buttons = new Button[3];

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.name == "MiniGameTrigger_1st")
        {
            buttons[0].gameObject.SetActive(true);
        }

        else if (gameObject.name == "MiniGameTrigger_2nd")
        {
            buttons[1].gameObject.SetActive(true);
        }

        else
        {
            buttons[2].gameObject.SetActive(true);
        }
    }

}
