using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class TriggerTowerForAttack : MonoBehaviour
    {
        private TowerAttack _towerAttack;

        private Transform _enemy;
        private GameObject _currentTarget;

        private bool _loockedOnTarget = false;

        void OnTriggerEnter(Collider triggeredCollider)
        {
            Debug.LogWarning("Trigger func working well");
            if (triggeredCollider.CompareTag("Enemy") && _loockedOnTarget != true)
            {
                Debug.Log("Triggered by enemy");
                _towerAttack.SetEnemy(triggeredCollider.gameObject.transform);
                _loockedOnTarget = true;
                _currentTarget = triggeredCollider.gameObject;
            }
        }

        void OnTriggerExit(Collider triggeredCollider)
        {
            if (triggeredCollider.CompareTag("Enemy") && triggeredCollider.gameObject == _currentTarget)
            {
                Debug.Log("Locked target left/dead => Searching for a new target");
                _loockedOnTarget = false;
            }
        }
    }

}
