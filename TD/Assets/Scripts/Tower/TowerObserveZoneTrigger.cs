#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class TowerObserveZoneTrigger : MonoBehaviour
    {
        private GameObject _currentTarget;

        private List<GameObject> _listOfExistingEnemies;

        void Start()
        {
            _listOfExistingEnemies = new List<GameObject>();
        }
        void OnTriggerEnter(Collider triggeredCollider)
        {
            if (triggeredCollider.gameObject.CompareTag("Enemy"))
            {
                _listOfExistingEnemies.Add(triggeredCollider.gameObject);
                Debug.Log("Added an enemy to the list");
            }
        }

        void Update()
        {
            if (_currentTarget == null)
            {
                ChooseATargetToFocus();
                Debug.Log("Choosing a target to focus");
            }
        }

        void OnTriggerExit(Collider triggeredCollider)
        {
            if (triggeredCollider.gameObject.CompareTag("Enemy"))
            {
                _listOfExistingEnemies.Remove(triggeredCollider.gameObject);
                Debug.Log("Removed from list an enemy");
            }

            if (triggeredCollider.gameObject == _currentTarget)
                ChooseATargetToFocus();
        }

        void ChooseATargetToFocus()
        {
            if (_listOfExistingEnemies.Count != 0)
                _currentTarget = _listOfExistingEnemies[Random.Range(0, _listOfExistingEnemies.Count)];
            else
                _currentTarget = null;
        }

        public GameObject GetCurrentTarget()
        {
            return _currentTarget;
        }
    }
}
