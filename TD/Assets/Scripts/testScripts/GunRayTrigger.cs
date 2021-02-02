using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class GunRayTrigger : MonoBehaviour
    {
        [HideInInspector] public Ray gunRay;
        void Start()
        {

        }
        void Update()
        {
            gunRay = new Ray(transform.position, transform.up);
            Debug.DrawRay(transform.position, transform.up * 10f, Color.cyan);
        }
    }

}