using System.Collections;
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
        public GameObject MapObj, CharCanvObj, CharactersObj, SoundObj, SoundOnObj, SounOffObj, MusicOnObj, MusicOffObj;
        private int MapsSelect;
        private static bool button = false;

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
            SoundObj.SetActive(false);
            if (curentIndex < ShopDataUI.ShopItems.Length - 1)
            {
                FindObjectOfType<AudioManager>().PlaySound("click");
                Characters[curentIndex].SetActive(false);
                curentIndex++;
                Characters[curentIndex].SetActive(true);
                setinfo();
                if(curentIndex == ShopDataUI.ShopItems.Length - 1) Next.gameObject.SetActive(false);
                if (Prev.gameObject.activeSelf == false) Prev.gameObject.SetActive(true);
                if (Select.gameObject.activeSelf == false) Select.gameObject.SetActive(true);
            }
            string shopMapDataString = SimpelDb.read("SaveDataShop");
            MapsSelect = shopMapDataString.Contains(":") ? int.Parse(shopMapDataString.Split(':', ',')[1]) : 0;
            if (curentIndex == MapsSelect)
                Select.gameObject.SetActive(false);
        }

        private void PrevBtnMeth()
        {
            SoundObj.SetActive(false);
            if (curentIndex > 0)
            {
                FindObjectOfType<AudioManager>().PlaySound("click");
                Characters[curentIndex].SetActive(false);
                curentIndex--;
                Characters[curentIndex].SetActive(true);
                setinfo();
                if (curentIndex == 0) Prev.gameObject.SetActive(false);
                if (Next.gameObject.activeSelf == false) Next.gameObject.SetActive(true);
                if (Select.gameObject.activeSelf == false) Select.gameObject.SetActive(true);
            }
            string shopMapDataString = SimpelDb.read("SaveDataShop");
            MapsSelect = shopMapDataString.Contains(":") ? int.Parse(shopMapDataString.Split(':', ',')[1]) : 0;
            if (curentIndex == MapsSelect)
                Select.gameObject.SetActive(false);
        }
        private void SelectBtnMeth()
        {
            FindObjectOfType<AudioManager>().PlaySound("click");
            SoundObj.SetActive(false);
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
            FindObjectOfType<AudioManager>().PlaySound("click");
            SceneManager.LoadSceneAsync(1);
        }
        public void MAp()
        {
            FindObjectOfType<AudioManager>().PlaySound("click");
            MapObj.SetActive(true);
            CharCanvObj.SetActive(false);
            CharactersObj.SetActive(false);
            SoundObj.SetActive(false);
        }
        public void characters()
        {
            FindObjectOfType<AudioManager>().PlaySound("click");
            MapObj.SetActive(false);
            CharCanvObj.SetActive(true);
            CharactersObj.SetActive(true);
            SoundObj.SetActive(false);
        }
        public void Sound()
        {
            FindObjectOfType<AudioManager>().PlaySound("click");
            SoundObj.active = !SoundObj.active;
        }
        public void SoundOn()
        {
            FindObjectOfType<AudioManager>().PlaySound("click");
            FindObjectOfType<AudioManager>().MuteSound("cancel");
            FindObjectOfType<AudioManager>().MuteSound("loos");
            FindObjectOfType<AudioManager>().MuteSound("femal jump");
            FindObjectOfType<AudioManager>().MuteSound("man jump");
            FindObjectOfType<AudioManager>().MuteSound("run");
            FindObjectOfType<AudioManager>().MuteSound("coin");
            FindObjectOfType<AudioManager>().MuteSound("slide");
            FindObjectOfType<AudioManager>().MuteSound("click");
            SounOffObj.SetActive(true);
            SoundOnObj.SetActive(false);

        }
        public void SoundOff()
        {
            FindObjectOfType<AudioManager>().PlaySound("click");
            FindObjectOfType<AudioManager>().MuteSound("cancel");
            FindObjectOfType<AudioManager>().MuteSound("loos");
            FindObjectOfType<AudioManager>().MuteSound("femal jump");
            FindObjectOfType<AudioManager>().MuteSound("man jump");
            FindObjectOfType<AudioManager>().MuteSound("run");
            FindObjectOfType<AudioManager>().MuteSound("coin");
            FindObjectOfType<AudioManager>().MuteSound("slide");
            FindObjectOfType<AudioManager>().MuteSound("click");
            SounOffObj.SetActive(false);
            SoundOnObj.SetActive(true);
        }
        public void MusicOn()
        {
            FindObjectOfType<AudioManager>().PlaySound("click");
            FindObjectOfType<AudioManager>().MuteSound("background");
            MusicOffObj.SetActive(true);
            MusicOnObj.SetActive(false);

        }
        public void MusicOff()
        {
            FindObjectOfType<AudioManager>().PlaySound("click");
            FindObjectOfType<AudioManager>().MuteSound("background");
            MusicOffObj.SetActive(false);
            MusicOnObj.SetActive(true);
        }
    }
}

