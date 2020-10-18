using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class TowerMenu : MonoBehaviour
    {
        [SerializeField] private bool towerMenuActive = false;
        GameObject towerMenu;
        
        void Start()
        {
            towerMenu = GameObject.Find("TowersInventory");
            towerMenu.SetActive(false);

            if (towerMenu == null)
            {
                Debug.LogError("Doesn't found tower menu in hierarchy");
            }
            else
            {
                Debug.Log("Found tower menu");
            }
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
    }

}