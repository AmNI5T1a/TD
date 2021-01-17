using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace TD_game
{
    public class DragAndDropTowerToMenuFromShop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private GameObject _itemForDragging;

        public bool itemDraggedInMenuSlot = false;
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnPointerDown");
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnEndDrag");
            if (itemDraggedInMenuSlot)
            {
                ///TODO: place icon and item to slot
            }
            else
            {
                _itemForDragging.SetActive(false);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("On dragging");
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(_itemForDragging, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);
        }
    }
}
