using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TD_game
{
    public class Tower_UI_Inventory : MonoBehaviour
    {
        private Inventory _towerInventory;

        private Transform _itemSlotContainer;
        private Transform _itemSlotTemplate;

        private Vector2 _itemSlotPosition;
        void Awake()
        {
            _itemSlotContainer = transform.Find("itemsContainer");
            _itemSlotTemplate = _itemSlotContainer.Find("itemSlotTemplate");

            if (_itemSlotTemplate == null)
                Debug.LogError("Tower_UI_Inventory: itemSlotTemplate doesn't found!");
            if (_itemSlotContainer == null)
                Debug.LogError("Tower_UI_Inventory: itemSlotContainer doesn't found!");

            _itemSlotPosition = new Vector2(-200, 1);
        }
        public void SetInventory(Inventory inventory)
        {
            this._towerInventory = inventory;
            RefreshInventory();
        }

        private void RefreshInventory()
        {
            foreach (Item item in _towerInventory.GetListOfItems())
            {
                RectTransform itemSlotRectTransform = Instantiate(_itemSlotTemplate, _itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
                itemSlotRectTransform.anchoredPosition = new Vector2(_itemSlotPosition.x, _itemSlotPosition.y);
                Image itemImage = itemSlotRectTransform.Find("icon").GetComponent<Image>();
                itemImage.sprite = item.GetItemSprite(item.level);
                _itemSlotPosition.x += 35f;
            }
        }
    }
}
