using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TD_game
{

    public class EnemyStats : MonoBehaviour
    {
        [Header("Stats: ")]
        [SerializeField] public float currentEnemyHealth = 0f;
        [SerializeField] public float maxEnemyHealth = 0f;

        [Header("References: ")]
        [SerializeField] private GameObject _healthBarUI;
        [SerializeField] private HealthBarSystem _healthBarSystem;

        void Awake()
        {
            currentEnemyHealth = maxEnemyHealth;
        }
        void Start()
        {
            currentEnemyHealth = maxEnemyHealth;
        }

        public void TakeDamage(float damage)
        {
            currentEnemyHealth -= damage;
            _healthBarSystem.UpdateHealthBarUI();

            if (currentEnemyHealth <= 0)
                KillEnemy();
        }
        public void KillEnemy()
        {
            Destroy(this.gameObject);
        }
    }
}
