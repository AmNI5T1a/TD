using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class Inventory
    {
        private List<Item> itemList;

        public Inventory()
        {
            itemList = new List<Item>();

            #region towerInventoryTestBlock
            AddItem(new Item { itemType = Item.ItemType.Tower, amount = 1, level = 1 });
            AddItem(new Item { itemType = Item.ItemType.Tower, amount = 1, level = 4 });
            AddItem(new Item { itemType = Item.ItemType.Tower, amount = 1, level = 1 });
            AddItem(new Item { itemType = Item.ItemType.Tower, amount = 1, level = 4 });
            // Debug.Log($"Count: {itemList.Count}");
            #endregion
        }

        public void AddItem(Item item)
        {
            itemList.Add(item);
        }

        public List<Item> GetListOfItems() => itemList;
    }
}