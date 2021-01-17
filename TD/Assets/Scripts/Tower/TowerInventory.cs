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

        private void InstanciateTowerInventory()
        {
            _towerInventory = new Inventory();
            _towerUI_Inventory.SetInventory(_towerInventory);
        }
    }
}
