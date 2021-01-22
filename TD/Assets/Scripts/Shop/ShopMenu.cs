using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD_game
{
    public class ShopMenu : MonoBehaviour
    {
        [SerializeField] private bool shopMenuStatus = false;
        private Inventory _shopInventory;

        private Transform _shopSlotContainer;
        private Transform _shopItemSlotTemplate;
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
                RectTransform itemSlotRectTransform = Instantiate(_shopItemSlotTemplate, _shopSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
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
                _shopMenu.SetActive(true);
                shopMenuStatus = true;
                _shopSlotContainer = transform.Find("shop_Content");
                _shopItemSlotTemplate = transform.Find("shop_itemTemplate");
                if (_shopSlotContainer != null && _shopItemSlotTemplate != null)
                    RefreshItemsInShopMenu();
                else
                    Debug.LogError("ShopMenu script: Can't update Menu cause stop template or container doesn't found");
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
