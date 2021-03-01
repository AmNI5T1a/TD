using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TD_game
{
    public class Tower_UI_Inventory : MonoBehaviour
    {
        [Header("References: ")]
        private Inventory _towerInventory;

        [SerializeField] private Transform _itemSlotContainer;
        [SerializeField] private Transform _itemSlotTemplate;

        private Vector2 _itemSlotPosition;

        [HideInInspector] public List<RectTransform> listOfSlots;
        void Awake()
        {
            CheckTemplateAndContainer();

            _itemSlotPosition = new Vector2(-200, 1);
        }

        void Start()
        {
            listOfSlots = new List<RectTransform>();
        }
        public void SetInventory(Inventory inventory)
        {
            this._towerInventory = inventory;
            RefreshInventory();
        }

        public void RefreshInventory()
        {
            DeleteSlotsBeforeUpdate(ref listOfSlots);

            foreach (Item item in _towerInventory.GetListOfItems())
            {
                RectTransform itemSlotRectTransform = Instantiate(_itemSlotTemplate, _itemSlotContainer).GetComponent<RectTransform>();
                listOfSlots.Add(itemSlotRectTransform);
                itemSlotRectTransform.gameObject.SetActive(true);
                itemSlotRectTransform.anchoredPosition = new Vector2(_itemSlotPosition.x, _itemSlotPosition.y);
                Image itemImage = itemSlotRectTransform.Find("icon").GetComponent<Image>();
                itemImage.sprite = item.GetItemSprite(item.level);
                _itemSlotPosition.x += 35f;
            }
        }

        void DeleteSlotsBeforeUpdate(ref List<RectTransform> listOfSlots)
        {
            foreach (RectTransform slot in listOfSlots)
            {
                Destroy(slot.gameObject);
            }
            _itemSlotPosition = new Vector2(-200, 1);
            listOfSlots.Clear();
        }

        private void CheckTemplateAndContainer()
        {
            if (_itemSlotTemplate == null)
                Debug.LogError("Tower_UI_Inventory: itemSlotTemplate doesn't found!");
            if (_itemSlotContainer == null)
                Debug.LogError("Tower_UI_Inventory: itemSlotContainer doesn't found!");
        }
    }
}
