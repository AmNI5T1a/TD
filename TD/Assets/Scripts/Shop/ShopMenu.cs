#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TD_game
{
    public class ShopMenu : MonoBehaviour
    {
        [SerializeField] private bool shopMenuStatus = false;
        private Inventory _shopInventory;

        [SerializeField] private Transform _shopSlotContainer;
        [SerializeField] private Transform _shopItemSlotTemplate;
        [SerializeField] private Transform _shopScrollView;

        [SerializeField] private GameObject _itemTemplate;
        private GameObject _shopMenu; // UI

        public void SetShopInventory(Inventory inventory)
        {
            this._shopInventory = inventory;
        }
        void Start()
        {
            _shopMenu = GameObject.Find("Shop");

            _shopMenu.SetActive(false);

            /// <summary>
            /// If Shop Menu doesn't found, debug shows log error
            /// <summary>
            ShopWasFoundTest(_shopMenu);
        }
        private void RefreshItemsInShopMenu()
        {
            foreach (Item item in _shopInventory.GetListOfItems())
            {
                GameObject inventoryItem = Instantiate(_itemTemplate, _shopSlotContainer);
                inventoryItem.gameObject.SetActive(true);
            }
        }
        public void OpenOrCloseShopMenu()
        {
            if (shopMenuStatus)
            {
                _shopMenu.SetActive(false);
                shopMenuStatus = false;
            }
            else
            {
                RefreshItemsInShopMenu();
                _shopMenu.SetActive(true);
                shopMenuStatus = true;
            }
        }

        public void CloseShopButton()
        {
            _shopMenu.SetActive(false);
            shopMenuStatus = false;
        }

        private void ShopWasFoundTest(GameObject shopMenu)
        {
            if (shopMenu == null)
                Debug.LogError("Shop Menu not found check ShopMenu script");
        }
    }
}
