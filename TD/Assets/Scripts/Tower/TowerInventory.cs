#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class TowerInventory : MonoBehaviour
    {
        [SerializeField] private Tower_UI_Inventory _towerUI_Inventory;
        private Inventory _towerInventory;
        void Start()
        {
            InstanciateTowerInventory();
        }

        void Update()
        {
            if (Input.GetKeyDown("p"))
            {
                AddItemToTowerInventory(ref _towerInventory);
                _towerUI_Inventory.RefreshInventory();
            }
        }

        private void InstanciateTowerInventory()
        {
            _towerInventory = new Inventory();
            _towerUI_Inventory.SetInventory(_towerInventory);
        }

        public void AddItemToTowerInventory(ref Inventory towerInventory)
        {
            towerInventory.AddItem(new Item { itemType = Item.ItemType.Tower, amount = 1, level = 4 });
        }
    }
}
