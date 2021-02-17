using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class PlasmaTower_horizontalRotation : MonoBehaviour
    {
        [Header("References: ")]
        [SerializeField] private PlasmaTowerAttack _plasmaTowerAttack = null;
        public void Rotate(GameObject target)
        {
            Quaternion direction = Quaternion.LookRotation(target.transform.position - this.transform.position);

            direction.z = 0f;
            direction.x = 0f;

            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, direction, _plasmaTowerAttack._horizontalRotationSpeed * Time.deltaTime);

        }
    }
}
