using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    [CreateAssetMenu(fileName = "ShopData",menuName = "Scriptable/Creat ShopData")]
    public class ShopData : ScriptableObject
    {
        public int SelectedIndex;
        public ShopItem[] ShopItems;
    }

    [System.Serializable]
    public class ShopItem
    {
        public string itemName;
        public bool isUnlocked;
        public int unlocCost;
    }
}

