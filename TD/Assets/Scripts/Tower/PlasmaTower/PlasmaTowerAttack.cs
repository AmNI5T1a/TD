#pragma warning disable 0649

using UnityEngine;
using System.Collections;

namespace TD_game
{

    public class PlasmaTowerAttack : MonoBehaviour
    {
        [Header("References: ")]
        [SerializeField] private TowerObserveZoneTrigger _observeZoneTrigger;
        [SerializeField] private PlasmaTower_gunRayTrigger _gunRayTrigger;

        [SerializeField] private PlasmaTower_horizontalRotation _horizontalRotation;
        [SerializeField] private PlasmaTower_verticalRotation _verticalRotation;
        [SerializeField] private GameObject _missilePrefab;
        [SerializeField] private Transform _missilePosition;

        [Header("Stats: ")]
        //[SerializeField] private byte _towerDamage = 20;
        [SerializeField] private byte _delayBetweenShots = 1;
        [SerializeField] public float _horizontalRotationSpeed = 0f;
        [SerializeField] public float _verticalRotationSpeed = 0f;

        [HideInInspector] public GameObject target;
        private bool _shooting = false;
        void Update()
        {
            target = _observeZoneTrigger.GetCurrentTarget();

            if (target != null)
            {
                RotateTowerToGetInSightAnEnemy();

                if (_gunRayTrigger.TargetInSight())
                {
                    Attack();
                }
            }
        }

        void RotateTowerToGetInSightAnEnemy()
        {
            _horizontalRotation.Rotate(target: target);
            _verticalRotation.Rotate(target: target);
        }

        void Attack()
        {
            if (!_shooting && _gunRayTrigger.TargetInSight())
            {
                StartCoroutine(Shoot());
            }
        }

        IEnumerator Shoot()
        {
            _shooting = true;
            GameObject projectile = GameObject.Instantiate(_missilePrefab, _missilePosition.position, _missilePosition.rotation);
            projectile.GetComponent<MissileMovement>().target = this.target.transform;
            yield return new WaitForSeconds(_delayBetweenShots);
            _shooting = false;
        }
    }
}
