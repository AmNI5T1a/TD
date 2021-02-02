#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class TowerAttack : MonoBehaviour
    {
        [SerializeField] private Transform _lookAtObj;
        [SerializeField] private GameObject _rocketPrefab;
        [SerializeField] private Transform _missilePosition;
        [SerializeField] public float towerDamage;
        [SerializeField] private float _delayBetweenShots;
        [SerializeField] private float towerRotateSpeed;
        public Transform target;
        private bool shooting = false;

        void Update()
        {
            if (target != null)
                Attack();

            // Ray gunPosition = new Ray(transform.position, transform.forward);
            // Debug.DrawRay(transform.position, transform.forward, Color.cyan);
        }
        void Attack()
        {
            Quaternion targetPosition = Quaternion.LookRotation(target.transform.position - _lookAtObj.transform.position);
            _lookAtObj.transform.rotation = Quaternion.RotateTowards(_lookAtObj.transform.rotation, targetPosition, towerRotateSpeed * Time.deltaTime);

            if (!shooting)
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

            if (target == null)
                Debug.LogError("TowerAttack script: Can't set an enemy");
        }
    }
}
