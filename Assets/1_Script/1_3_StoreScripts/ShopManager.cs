using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    int flowerPrice;
    int winePrice;
    int breadPrice;

    public static int flowerCount;
    public static int wineCount;
    public static int breadCount;

    public Text CurrentDia;
    public Text FlowerPrice;
    public Text WinePrice;
    public Text BreadPrice;

    public GameObject ShopDialog;
    public GameObject btn_Flower;
    public GameObject btn_Wine;
    public GameObject btn_Bread;

    public Image Flower;
    public Image Wine;
    public Image Bread;

    public Camera cam;

    void Start()
    {
        Flower.gameObject.SetActive(false);
        Wine.gameObject.SetActive(false);
        Bread.gameObject.SetActive(false);


        flowerCount = 0;
        wineCount = 0;
        breadCount = 0;

        flowerPrice = 20;
        winePrice = 20;
        breadPrice = 20;

    }

    void Update()
    {
        CurrentDia.text = "" + MainGameManager.coin;
    }

    public void FlowerBuy()
    {
        if(MainGameManager.coin >= flowerPrice && flowerCount == 0)
        {
            MainGameManager.coin -= flowerPrice;
            flowerCount++;
        }
        if(flowerCount >= 1)
        {
            Flower.gameObject.SetActive(true);

            btn_Flower.GetComponent<Button>().interactable = false;
        }
    }
    public void WineBuy()
    {
        if (MainGameManager.coin >= winePrice && wineCount == 0)
        {
            MainGameManager.coin -= winePrice;
            wineCount++;
        }
        if (wineCount >= 1)
        {
            Wine.gameObject.SetActive(true);
            btn_Wine.GetComponent<Button>().interactable = false;
        }
    }

    public void BreadBuy()
    {
        if (MainGameManager.coin >= breadPrice && breadCount == 0)
        {
            MainGameManager.coin -= breadPrice;
            breadCount++;
        }
        if (breadCount >= 1)
        {
            Bread.gameObject.SetActive(true);

            btn_Bread.GetComponent<Button>().interactable = false;
        }
    }
    public void Exit()
    {
        ShopDialog.SetActive(false);
        cam.gameObject.SetActive(false);
        MainGameManager.objs.SetActive(true);
    }
}
