﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class PlasmaTower_verticalRotation : MonoBehaviour
    {
        [Header("References: ")]
        [SerializeField] private PlasmaTowerAttack _plasmaTowerAttack;
        public void Rotate(GameObject target)
        {
            Quaternion direction = Quaternion.LookRotation(target.transform.position - this.transform.position);

            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, direction, _plasmaTowerAttack._verticalRotationSpeed * Time.deltaTime);
        }
    }
}

