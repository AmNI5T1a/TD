using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class MissileMovement : MonoBehaviour
    {
        [SerializeField] public float speed;

        [HideInInspector] public Transform target;

        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }
    }
}
