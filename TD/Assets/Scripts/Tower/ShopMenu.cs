using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD_game
{
    public class ShopMenu : MonoBehaviour
    {
        [SerializeField] private bool shopMenuStatus = false;

        private GameObject shopMenu;
        void Start()
        {
            shopMenu = GameObject.Find("Shop");

            shopMenu.SetActive(false);

            /// <summary>
            /// If Shop Menu doesn't found, debug shows log error
            /// <summary>
            ShopWasFoundTest(shopMenu);
        }

        public void OpenOrCloseShopMenu()
        {
            if (shopMenuStatus)
            {
                shopMenu.SetActive(false);
                shopMenuStatus = false;
            }
            else
            {
                shopMenu.SetActive(true);
                shopMenuStatus = true;
            }
        }

        private void ShopWasFoundTest(GameObject shopMenu)
        {
            if (shopMenu == null)
                Debug.LogError("Shop Menu not found check ShopMenu script");
        }
    }
}
