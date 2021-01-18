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
        public ushort amount;
        public byte level;
        public ushort price;

        public Sprite GetItemSprite(byte itemLevel)
        {
            if (itemLevel == 1)
            {
                switch (itemType)
                {
                    case ItemType.Tower: return ItemAssets.Instance.tower_1lvl;
                    case ItemType.Potion: return ItemAssets.Instance.potion_1lvl;
                }
            }
            else if (itemLevel == 4)
            {
                switch (itemType)
                {
                    case ItemType.Tower: return ItemAssets.Instance.tower_4lvl;
                    case ItemType.Potion: return ItemAssets.Instance.potion_4lvl;
                }
            }
            return ItemAssets.Instance.unknownSprite;
        }
    }
}

