using UnityEngine;

namespace TD_game
{
    public class MissileMovement : MonoBehaviour
    {
        [SerializeField] public float speed = 1000;

        [HideInInspector] public Transform target;

        [HideInInspector] private Rigidbody _missileRigidbody;

        private Vector3 _direction;

        void Start()
        {
            _missileRigidbody = this.GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (target != null)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
                this.transform.LookAt(target);
            }
            else
                ExploideMissile();
        }

        private void ExploideMissile()
        {
            Destroy(this.gameObject);
        }
    }
}
