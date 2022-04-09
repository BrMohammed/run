﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    public class SaveLodeData : MonoBehaviour
    {

        [SerializeField] private ShopUi shopUi;
        public void Initialized()
        {
            if (int.Parse(SimpelDb.read("gamestart")) == 1)
                LoadData();
            else
            {
                SaveData();
                SimpelDb.update(1.ToString(), "gamestart");
            }
        }
        public void SaveData()
        {
            string ShopDataString = JsonUtility.ToJson(shopUi.ShopDataUI);
            SimpelDb.update(ShopDataString, "SaveDataShop");
            Debug.Log(ShopDataString);
            Debug.Log("Saved");
        }
        public void LoadData()
        {
            string shopDataString = SimpelDb.read("SaveDataShop");
            shopUi.ShopDataUI = new ShopData();
            shopUi.ShopDataUI = JsonUtility.FromJson<ShopData>(shopDataString);
            Debug.Log("Loaded");
        }
        public void ClearData()
        {
            Debug.Log("Clear");
            SimpelDb.update(0.ToString(), "gamestart");
        }
    }
}



