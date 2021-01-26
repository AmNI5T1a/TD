#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    // This module for calling ShopMenu
    public class Shop : MonoBehaviour
    {
        [SerializeField] private ShopMenu _uiShopMenu;
        private Inventory _shopInventory;
        void Start()
        {
            InstanciateShopInventory();
        }

        private void InstanciateShopInventory()
        {
            _shopInventory = new Inventory();
            _uiShopMenu.SetShopInventory(_shopInventory);
        }
    }
}
