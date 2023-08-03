using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour {

  
    public GameObject[] FXList;
    public Text Title;
    public int Selection = 0;

    public GameObject BackText;
    public GameObject NextText;
    public GameObject BackButton;
    public GameObject NextButton;
    public GameObject NextOutline;
    public GameObject BackOutline;

    public GameObject Diana;
    public bool Variations = false;
    public GameObject[] Variants;

    void Start () {
        FXList[Selection].SetActive(true);
        Diana.SetActive(false);
        Title.text = FXList[Selection].gameObject.transform.name.ToString();
    }
	void Update()
    {
        if(Variations == false)
        {
            if (FXList[Selection].gameObject.transform.name == "Fireball (Projectile)" ||
            FXList[Selection].gameObject.transform.name == "Lightning Ball (Projectile)" ||
            FXList[Selection].gameObject.transform.name == "Poison (Projectile)")
            {
                Diana.SetActive(true);
            }
            else
            {
                Diana.SetActive(false);
            }

        }
        if(Variations == true)
        {
            Diana.SetActive(false);
        }

        if(Selection == 0)
        {
            BackText.SetActive(false);
            BackButton.SetActive(false);
            BackOutline.SetActive(false);
        }
        else
        {
            BackText.SetActive(true);
            BackButton.SetActive(true);
            BackOutline.SetActive(true);
        }

        if(Selection == FXList.Length - 1 && Variations == false)
        {
            NextText.SetActive(false);
            NextButton.SetActive(false);
            NextOutline.SetActive(false);
        }
        if (Selection != FXList.Length - 1 && Variations == false)
        {
            NextText.SetActive(true);
            NextButton.SetActive(true);
            NextOutline.SetActive(true);
        }

        if (Selection == Variants.Length - 1 && Variations == true)
        {
            NextText.SetActive(false);
            NextButton.SetActive(false);
            NextOutline.SetActive(false);
        }
        if (Selection != Variants.Length - 1 && Variations == true)
        {
            NextText.SetActive(true);
            NextButton.SetActive(true);
            NextOutline.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Next();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Back();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Canvas C;
            C = GetComponent<Canvas>();
            C.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Canvas C;
            C = GetComponent<Canvas>();
            C.enabled = true;
        }

    }
    public void Back()
    {
       
        if (Selection < FXList.Length && Selection != 0 && Variations == false)
        {
            FXList[Selection].SetActive(false);
            Selection -= 1;
            FXList[Selection].SetActive(true);
            Title.text = FXList[Selection].gameObject.transform.name.ToString();
        }

        if (Selection < Variants.Length && Selection != 0 && Variations == true)
        {
            Variants[Selection].SetActive(false);
            Selection -= 1;
            Variants[Selection].SetActive(true);
            Title.text = Variants[Selection].gameObject.transform.name.ToString();
        }

    }

    public void Next()
    {
       
        if(Selection < FXList.Length && Selection != FXList.Length - 1 && Variations == false)
        {
            FXList[Selection].SetActive(false);
            Selection += 1;
            FXList[Selection].SetActive(true);
            Title.text = FXList[Selection].gameObject.transform.name.ToString();
        }

        if (Selection < Variants.Length && Selection != Variants.Length - 1 && Variations == true)
        {
            Variants[Selection].SetActive(false);
            Selection += 1;
            Variants[Selection].SetActive(true);
            Title.text = Variants[Selection].gameObject.transform.name.ToString();
        }

    }

    public void ColorVariations(bool V)
    {
        Variations = V;
       
        if(V == true)
        {
            Last();
            Selection = 0;
            Variants[Selection].SetActive(true);
            Diana.SetActive(false);
            Title.text = Variants[Selection].gameObject.transform.name.ToString();
        }
        else
        {
            Last();
            Selection = 0;
            FXList[Selection].SetActive(true);
            Diana.SetActive(false);
            Title.text = FXList[Selection].gameObject.transform.name.ToString();
        }
    }

    public void Last()
    {
        if (Selection < FXList.Length && Variations == true)
        {
            FXList[Selection].SetActive(false);
        }
        if (Selection < Variants.Length && Variations == false)
        {
            Variants[Selection].SetActive(false);
        }

    }

}
