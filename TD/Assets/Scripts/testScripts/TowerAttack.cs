#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class TowerAttack : MonoBehaviour
    {
        [SerializeField] private Transform _elementForShoot;
        [SerializeField] private Transform _lookAtObj;
        [SerializeField] private GameObject _rocketPrefab;

        [SerializeField] public float towerDamage;
        [SerializeField] private float _delayBetweenShots;
        [SerializeField] private float towerRotateSpeed;
        public Transform target;

        void Update()
        {
            if (target != null)
                Attack();
        }
        void Attack()
        {
            //_lookAtObj.transform.LookAt(target: target);

            Quaternion targetPosition = Quaternion.LookRotation(target.transform.position - _lookAtObj.transform.position);
            _lookAtObj.transform.rotation = Quaternion.RotateTowards(_lookAtObj.transform.rotation, targetPosition, towerRotateSpeed * Time.deltaTime);

            //StartCoroutine(Shoot());
        }

        IEnumerator Shoot()
        {
            yield return new WaitForSeconds(_delayBetweenShots);
            GameObject missile = GameObject.Instantiate(_rocketPrefab, _elementForShoot.position, Quaternion.identity);
            missile.GetComponent<MissileMovement>().target = this.target;
        }

        public void SetEnemy(GameObject enemy)
        {
            target = enemy.transform;

            if (target == null)
                Debug.LogError("TowerAttack script: Can't set an enemy");
        }
    }
}
