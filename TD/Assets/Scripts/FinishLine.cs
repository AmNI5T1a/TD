using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD_game
{
    public class FinishLine : MonoBehaviour
    {
        private bool onTriggerEnter = false;
        private MobSpawner mobSpawner;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy")
            {
                Destroy(other.gameObject, 1f);
                onTriggerEnter = true;
            }
        }
        void Awake()
        {
            MobSpawner mobSpawner = GameObject.Find("MobSpawner").GetComponent<MobSpawner>();
        }
        void Update()
        {
            if (onTriggerEnter && mobSpawner !=null)
            {
                mobSpawner.currentNumberOfMobs--;
                onTriggerEnter = false;
            }
        }
    }
}
