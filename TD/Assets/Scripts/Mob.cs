using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class Mob : MonoBehaviour
    {
        [SerializeField] private float enemySpeed;

        [SerializeField] public List<Transform> waypoints = new List<Transform>();

        [HideInInspector] private byte _currentWaypointIndex = 0;

        void Start()
        {
            GameObject _object = GameObject.Find("Waypoint1");
            waypoints[0] = _object.transform;
            _object = GameObject.Find("Waypoint2");
            waypoints[1] = _object.transform;
        }

        void Update()
        {
            if (_currentWaypointIndex < waypoints.Count)
            {
                transform.position = Vector3.Lerp(transform.position, waypoints[_currentWaypointIndex].position, Time.deltaTime * enemySpeed);
                if (Vector3.Distance(transform.position, waypoints[_currentWaypointIndex].position) < 0.5f)
                {
                    _currentWaypointIndex++;
                }
            }
        }
    }
    class MobMovement
    {
        private void Movement()
        {

        }
    }
}
