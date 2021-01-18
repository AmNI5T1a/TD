using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class Shop : MonoBehaviour
    {
        private Inventory _shopInventory;
        void Start()
        {
            InstanciateShopInventory();
        }

        private void InstanciateShopInventory()
        {
            _shopInventory = new Inventory();
        }
    }
}
