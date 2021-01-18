using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class ItemAssets : MonoBehaviour
    {
        public static ItemAssets Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public Sprite unknownSprite;
        public Sprite tower_1lvl;
        public Sprite tower_4lvl;


        public Sprite potion_1lvl;
        public Sprite potion_4lvl;

    }
}
