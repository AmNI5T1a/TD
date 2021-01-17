using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class ItemInformation : MonoBehaviour
    {
        [SerializeField] public GameObject imageAndIconOfItem;

        public bool itemPurchased;

        void Start()
        {
            itemPurchased = false;
        }
    }
}

