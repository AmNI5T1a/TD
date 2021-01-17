using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class Item
    {
        public enum ItemType
        {
            Tower,
            Potion
        }

        public ItemType itemType;
        public int amount;
    }
}

