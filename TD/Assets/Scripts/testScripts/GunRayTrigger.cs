using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class GunRayTrigger : MonoBehaviour
    {
        [HideInInspector] public Ray gunRay;
        void Update()
        {
            gunRay = new Ray(transform.position, -transform.up);
            Debug.DrawRay(transform.position, -transform.up * 10f, Color.cyan);
        }

        public bool TargetInSight()
        {
            RaycastHit hit;

            if (Physics.Raycast(gunRay, out hit))
            {
                var selection = hit.collider.gameObject;

                if (selection.CompareTag("Enemy"))
                    return true;
            }
            return false;
        }
    }
}