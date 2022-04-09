﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ShopSystem
{
    public class ShopUi : MonoBehaviour
    {
        public int Shopcoin;
        public ShopData ShopDataUI;
        public GameObject[] Characters;
        public Text UnlockBtnText,Totalcoin;
        public Button Next, Prev, Select;
        private int curentIndex = 0;
        private int SelectedIndex = 0;
        public SaveLodeData saveLodeData;

        void Start()
        {
            Shopcoin = int.Parse(SimpelDb.read("TotalCoin"));
            saveLodeData.Initialized();
            SelectedIndex = ShopDataUI.SelectedIndex;
            curentIndex = SelectedIndex;
            Totalcoin.text = "" + Shopcoin;
            Next.onClick.AddListener(() => NextBtnMeth());
            Prev.onClick.AddListener(() => PrevBtnMeth());
            Select.onClick.AddListener(() => SelectBtnMeth());
            setinfo();
            Characters[curentIndex].SetActive(true);
            Select.gameObject.SetActive(false);
            if (curentIndex == 0) Prev.gameObject.SetActive(false);
            if (curentIndex == ShopDataUI.ShopItems.Length - 1) Next.gameObject.SetActive(false);
        }
        private void setinfo()
        {
            if (ShopDataUI.ShopItems[curentIndex].unlocCost == 0)
                UnlockBtnText.text = "Select";
            else
                UnlockBtnText.text = ShopDataUI.ShopItems[curentIndex].unlocCost.ToString();
        }

        private void NextBtnMeth()
        {
            if (curentIndex < ShopDataUI.ShopItems.Length - 1)
            {
                Characters[curentIndex].SetActive(false);
                curentIndex++;
                Characters[curentIndex].SetActive(true);
                setinfo();
                if(curentIndex == ShopDataUI.ShopItems.Length - 1) Next.gameObject.SetActive(false);
                if (Prev.gameObject.activeSelf == false) Prev.gameObject.SetActive(true);
                if (Select.gameObject.activeSelf == false) Select.gameObject.SetActive(true);
            }
        }

        private void PrevBtnMeth()
        {
            if (curentIndex > 0)
            {
                Characters[curentIndex].SetActive(false);
                curentIndex--;
                Characters[curentIndex].SetActive(true);
                setinfo();
                if (curentIndex == 0) Prev.gameObject.SetActive(false);
                if (Next.gameObject.activeSelf == false) Next.gameObject.SetActive(true);
                if (Select.gameObject.activeSelf == false) Select.gameObject.SetActive(true);
            }
        }
        private void SelectBtnMeth()
        {
            bool yes_is_selected = false;
            if(ShopDataUI.ShopItems[curentIndex].isUnlocked == true)
                yes_is_selected = true;
            if (Shopcoin >= ShopDataUI.ShopItems[curentIndex].unlocCost)
            {
                Shopcoin -= ShopDataUI.ShopItems[curentIndex].unlocCost;
                ShopDataUI.ShopItems[curentIndex].unlocCost = 0;
                UnlockBtnText.text = "Select";
                Totalcoin.text = "" + Shopcoin;
                SimpelDb.update(Shopcoin.ToString(), "TotalCoin");
                yes_is_selected = true;
                ShopDataUI.ShopItems[curentIndex].isUnlocked = true;
                saveLodeData.SaveData();
            }
            if(yes_is_selected == true)
            {
                UnlockBtnText.text = "Select";
                SelectedIndex = curentIndex;
                ShopDataUI.SelectedIndex = SelectedIndex;
                Select.gameObject.SetActive(false);
                saveLodeData.SaveData();
            }
        }
        public void GoHme()
        {
            SceneManager.LoadSceneAsync(1);
        }

    }
}

