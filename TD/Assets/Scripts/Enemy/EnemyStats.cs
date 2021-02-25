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
        [SerializeField] private Slider _healthBarSlider;

        void Awake()
        {
            currentEnemyHealth = maxEnemyHealth;

            _healthBarSlider.value = CalculateHealthToSlider();
        }
        void Start()
        {
            _healthBarUI.SetActive(false);
        }

        void Update()
        {

        }

        public void KillEnemy()
        {
            Destroy(this.gameObject);
        }
        public float CalculateHealthToSlider() => currentEnemyHealth / maxEnemyHealth;
    }
}
