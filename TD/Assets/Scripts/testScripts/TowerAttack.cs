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
        public Transform target;

        void Update()
        {
            if (target != null)
                Attack();
        }
        void Attack()
        {
            _lookAtObj.transform.LookAt(target: target);
            StartCoroutine(Shoot());
        }

        IEnumerator Shoot()
        {
            yield return new WaitForSeconds(_delayBetweenShots);
            GameObject missile = GameObject.Instantiate(_rocketPrefab, _elementForShoot.position, Quaternion.identity);
            missile.GetComponent<MissileMovement>().target = this.target;
        }

        public void SetEnemy(Transform enemy)
        {
            target = enemy;

            if (target == null)
                Debug.LogError("TowerAttack script: Can't set an enemy");
        }
    }
}
