using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class ProjectileMovement : MonoBehaviour
    {
        [Header("Stats: ")]
        [SerializeField] private float speed = 10;

        [Header("References (working only in play mode): ")]
        [Tooltip("Prefab will take enemy position after instanciation")]
        public Transform target;

        private Rigidbody _projectileRigidbody;


        void Awake()
        {
            _projectileRigidbody = this.GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (target != null)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                this.transform.LookAt(target);
            }
            else
            {
                ExploideProjectile();
            }
        }

        void ExploideProjectile()
        {
            Destroy(this);
        }
    }
}