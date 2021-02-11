#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class TowerObserveZoneTrigger : MonoBehaviour
    {
        private GameObject _currentTarget;
        private bool _lockedOnTarget = false;

        void OnTriggerEnter(Collider triggeredCollider)
        {
            if (triggeredCollider.CompareTag("Enemy") && _lockedOnTarget != true)
            {
                _lockedOnTarget = true;
                _currentTarget = triggeredCollider.gameObject;
            }
        }

        void OnTriggerExit(Collider triggeredCollider)
        {
            if (triggeredCollider.CompareTag("Enemy") && triggeredCollider.gameObject == _currentTarget)
            {
                _lockedOnTarget = false;
                _currentTarget = null;
            }
        }

        public GameObject GetCurrentTarget()
        {
            return _currentTarget;
        }
    }
}
