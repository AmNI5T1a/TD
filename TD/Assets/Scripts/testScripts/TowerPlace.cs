using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class TowerPlace : MonoBehaviour
    {
        [SerializeField] private GameObject _towerPrefab;

        private bool _towerPlaceIsEmpty = true;

        void OnMouseDown()
        {
            if (_towerPlaceIsEmpty)
            {
                GameObject tower = GameObject.Instantiate(_towerPrefab, transform.position + new Vector3(3.7f, -0.8f, 1.05f), Quaternion.identity);
                _towerPlaceIsEmpty = false;
            }
        }
    }
}
