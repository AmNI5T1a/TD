#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class TriggerTowerForAttack : MonoBehaviour
    {
        [SerializeField] private TowerAttack _towerAttack;

        //private Transform _enemy;
        private GameObject _currentTarget;

        private bool _lockedOnTarget = false;

        void OnTriggerEnter(Collider triggeredCollider)
        {
            if (triggeredCollider.CompareTag("Enemy") && _lockedOnTarget != true)
            {
                _towerAttack.SetEnemy(triggeredCollider.gameObject);
                _lockedOnTarget = true;
                _currentTarget = triggeredCollider.gameObject;
            }
        }

        void OnTriggerExit(Collider triggeredCollider)
        {
            if (triggeredCollider.CompareTag("Enemy") && triggeredCollider.gameObject == _currentTarget)
            {
                _lockedOnTarget = false;
                _towerAttack.target = null;
            }
        }
    }

}
