using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{


    public class HitRegister : MonoBehaviour
    {
        void OnTriggerEnter(Collider enteredCollider)
        {
            if (enteredCollider.gameObject.tag == "Projectile")
            {
                Debug.Log("Hitted by missle");
            }
        }
    }
}