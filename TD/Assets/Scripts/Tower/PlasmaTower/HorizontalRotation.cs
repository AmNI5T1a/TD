using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class HorizontalRotation : MonoBehaviour
    {
        [Header("References: ")]
        [SerializeField] private PlasmaTowerAttack _plasmaTower;

        void Update()
        {

        }

        void Rotate(GameObject target)
        {
            Vector3 targetHorizontalPosition = new Vector3(transform.position.x, transform.position.y, target.transform.position.z);

            transform.LookAt(targetHorizontalPosition);
        }
    }
}
