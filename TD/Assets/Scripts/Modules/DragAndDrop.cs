using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace TD_game
{
    public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private GameObject towerPrefab;
        [HideInInspector] private RectTransform rectTransform;
        public void OnBeginDrag(PointerEventData eventdata)
        {
            Vector3 mousePosition = Input.mousePosition;
            //mousePosition.z+=25f;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePosition);
            GameObject tower = Instantiate(towerPrefab,objectPos, Quaternion.identity);
        }

        public void OnDrag(PointerEventData eventdata)
        {
            Debug.LogWarning("dragging");
        }

        public void OnEndDrag(PointerEventData eventdata)
        {

        }
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.LogWarning("Pointer Down");
        }
    }

}

