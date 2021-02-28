using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{


    public class HitRegister : MonoBehaviour
    {
        [Header("References: ")]
        [SerializeField] private EnemyStats _enemyStats;
        void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "Projectile")
            {
                _enemyStats.TakeDamage(collider.gameObject.GetComponent<ProjectileMovement>().damage);
                Destroy(collider.gameObject);
            }
        }
    }
}