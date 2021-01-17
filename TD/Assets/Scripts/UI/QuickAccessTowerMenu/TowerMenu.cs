using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class TowerMenu : MonoBehaviour
    {
        [SerializeField] private bool towerMenuActive = false;
        private GameObject towerMenu;

        void Start()
        {
            towerMenu = GameObject.Find("TowerInventory");
            towerMenu.SetActive(false);


            /// <summary>
            /// If Tower Menu doesn't found, debug shows log error
            /// <summary>
            TowerMenuTestModul(towerMenu);
        }
        public void OpenCloseTowerMenu()
        {

            if (towerMenuActive)
            {
                towerMenu.SetActive(false);
                towerMenuActive = false;
            }
            else
            {
                towerMenu.SetActive(true);
                towerMenuActive = true;
            }
        }

        private void TowerMenuTestModul(GameObject towerMenu)
        {
            if (towerMenu == null)
            {
                Debug.LogError("Tower Menu not found check TowerMenu script");
            }
        }
    }
}