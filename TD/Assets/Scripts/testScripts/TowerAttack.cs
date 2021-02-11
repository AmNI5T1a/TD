#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class TowerAttack : MonoBehaviour
    {
        [Header("Serialized fields")]
        [SerializeField] private Transform _lookAtObj;
        [SerializeField] private GameObject _rocketPrefab;
        [SerializeField] private Transform _missilePosition;
        [SerializeField] private PlasmaTower_gunRayTrigger _gunRay;
        [Header("Stats")]
        [SerializeField] public float towerDamage;
        [SerializeField] private float _delayBetweenShots;
        [SerializeField] private float towerRotateSpeed;
        public Transform target;
        private bool shooting = false;
        public bool targetInSight = false;

        void Update()
        {
            if (target != null)
            {
                Attack();
            }
        }
        void Attack()
        {
            Quaternion targetPosition = Quaternion.LookRotation(target.transform.position - _lookAtObj.transform.position);
            _lookAtObj.transform.rotation = Quaternion.RotateTowards(_lookAtObj.transform.rotation, targetPosition, towerRotateSpeed * Time.deltaTime);

            if (!shooting && _gunRay.TargetInSight())
                StartCoroutine(Shoot());
        }

        IEnumerator Shoot()
        {
            shooting = true;
            Debug.Log("Shooting");
            GameObject missile = GameObject.Instantiate(_rocketPrefab, _missilePosition.position, _missilePosition.rotation);
            missile.GetComponent<MissileMovement>().target = this.target;
            yield return new WaitForSeconds(_delayBetweenShots);
            shooting = false;
        }

        public void SetEnemy(GameObject enemy)
        {
            target = enemy.transform;
        }
    }
}
