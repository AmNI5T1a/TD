using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class MobMovement : MonoBehaviour
    {
        [SerializeField]
        public float enemySpeed;
        [HideInInspector]
        public byte _currentWaypointIndex = 0;

        [SerializeField]
        public GameObject fisrtSpawnpoint;

        private List<Transform> waypoints = new List<Transform>();
        private bool _generateNewRoute = false;

        void Start()
        {
            InitializeWaypoints();
            CheckRoute();
            if (_generateNewRoute)
            {
                waypoints = GenerateNewRoute();
                Debug.LogWarning("Generated new route");
                // for (byte c = 0; c < waypoints.Count; c++)
                // {
                //     Debug.Log($"{c}: X:{waypoints[c].position.x.ToString()} Z:{waypoints[c].position.z.ToString()}");
                // }
            }
        }

        void Update()
        {
            Movement();
        }
        private void Movement()
        {
            //check spwawnpoint 
            if (_currentWaypointIndex < waypoints.Count)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypointIndex].position, Time.deltaTime * enemySpeed);
                transform.LookAt(waypoints[_currentWaypointIndex].position);
                if (Vector3.Distance(transform.position, waypoints[_currentWaypointIndex].position) < 0.5f)
                {
                    _currentWaypointIndex++;
                }
            }
        }
        private List<Transform> GenerateNewRoute()
        {
            List<Transform> newRoute = new List<Transform>();

            Transform currentNearestPoint = waypoints[8];

            for (byte k = 0; k < waypoints.Count; k++)
            {
                for (byte j = 0; j < waypoints.Count; j++)
                {
                    if (Vector3.Distance(transform.position, waypoints[j].position) < Vector3.Distance(transform.position, currentNearestPoint.position))
                    {
                        if (!newRoute.Contains(waypoints[j]))
                            currentNearestPoint = waypoints[j];
                    }
                }
                if (!newRoute.Contains(currentNearestPoint))
                {
                    newRoute.Add(currentNearestPoint);
                    Debug.LogWarning($"Added new point to newRoute: {currentNearestPoint.position.ToString()}");
                }
            }
            return newRoute;
        }
        void InitializeWaypoints()
        {
            foreach (GameObject respawn in GameObject.FindGameObjectsWithTag("Waypoint"))
            {
                waypoints.Add(respawn.transform);
                //Debug.LogWarning("Found and added this point to waypoints list");
            }

            if (waypoints != null && waypoints.Count != 0)
            {
                //Debug.Log("Added waypoints in list for new mob");
                Debug.LogWarning($"{waypoints.Count.ToString()}");
            }
            else
            {
                Debug.LogError("Check code waypoints list is empty right now...");
            }
        }
        void CheckRoute()
        {
            GameObject spawnpoint = GameObject.Find("Spawnpoint1");

            if (Vector3.Distance(transform.position, spawnpoint.transform.position) < 3)
            {
                //Debug.Log("Following route from first spawnpoint");
                RouteFrom1Spawnpoint firstRoute = new RouteFrom1Spawnpoint();
                firstRoute.FollowRoute(ref waypoints, ref _generateNewRoute);
            }
            else
            {
                //Debug.Log("Following route from 2 spawnpoint");
                RouteFrom2Spawnpoint secondRoute = new RouteFrom2Spawnpoint();
                secondRoute.FollowRoute(ref waypoints, ref _generateNewRoute);
            }
        }
        abstract class RouteFollower
        {
            public abstract void FollowRoute(ref List<Transform> listOfWaypoints, ref bool generateNewRoute);
        }

        class RouteFrom1Spawnpoint : RouteFollower
        {
            public override void FollowRoute(ref List<Transform> listOfWaypoints, ref bool generateNewRoute)
            {
                List<Transform> newRoute = new List<Transform>();
                newRoute.Add(listOfWaypoints[8]);
                listOfWaypoints = newRoute;
                generateNewRoute = false;
            }
        }
        class RouteFrom2Spawnpoint : RouteFollower
        {
            public override void FollowRoute(ref List<Transform> listOfWaypoints, ref bool generateNewRoute)
            {
                generateNewRoute = true;
            }
        }
    }
}

