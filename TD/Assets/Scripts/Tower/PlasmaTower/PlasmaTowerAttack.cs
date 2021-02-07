using UnityEngine;

namespace TD_game
{

    public class PlasmaTowerAttack : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TowerObserveZoneTrigger _observeZoneTrigger;
        [SerializeField] private PlasmaTower_gunRayTrigger _gunRayTrigger;

        [SerializeField] private HorizontalRotation _horizontalRotation;
        [SerializeField] private VerticalRotation _vertivalRotation;

        [HideInInspector] public GameObject target;
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

        }

        void Attack()
        {

        }
    }
}
