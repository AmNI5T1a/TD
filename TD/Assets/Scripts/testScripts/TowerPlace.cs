﻿#pragma warning disable 0649

using UnityEngine;

namespace TD_game
{
    public class TowerPlace : MonoBehaviour
    {
        [SerializeField] private GameObject _towerPrefab;

        public bool TowerPlaceIsEmpty = true;

        void OnMouseDown()
        {
            if (TowerPlaceIsEmpty)
            {
                GameObject tower = GameObject.Instantiate(_towerPrefab, transform.position, Quaternion.identity) as GameObject;
                //+ new Vector3(3.7f, -0.8f, 1.05f)
                TowerPlaceIsEmpty = false;
            }
        }
    }
}
