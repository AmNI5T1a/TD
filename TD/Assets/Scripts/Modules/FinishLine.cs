﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD_game
{
    public class FinishLine : MonoBehaviour
    {
        private MobSpawner mobSpawner = null;
        [Range(0, 1)]
        public float destroyDelay = 0.75f;
        void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "Enemy")
            {
                Destroy(collider.gameObject, destroyDelay);
                mobSpawner.currentNumberOfMobs -= 1;
            }
        }
        void Start()
        {
            InitializeMobSpawner();
        }

        private void InitializeMobSpawner()
        {
            mobSpawner = GameObject.Find("MobSpawner").GetComponent<MobSpawner>();

            if (mobSpawner == null)
                Debug.LogError("Doesn't found mob spawner");
        }
    }
}
