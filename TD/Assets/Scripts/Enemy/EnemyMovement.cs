using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace TD_game
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField]
        private GameObject _destination;

        [SerializeField]
        private NavMeshAgent _navMeshAgent;

        void Start()
        {
            InitializeTargetDestination();
            InitializeNavMesh(ref _navMeshAgent);

        }

        void InitializeNavMesh(ref NavMeshAgent navMeshAgent)
        {
            navMeshAgent = this.GetComponent<NavMeshAgent>();

            if (navMeshAgent == null)
                Debug.LogError("Nav mesh agent is empty on :" + this.name);
            else
                SetDestination();
        }
        void InitializeTargetDestination()
        {
            if (_destination == null)
                _destination = GameObject.FindGameObjectWithTag("Finish");
            else
                Debug.LogError("Doesn't found object with tag : Finish in InitializeTargetDestination method");
        }

        void SetDestination()
        {
            if (_destination != null)
            {
                Vector3 targetDestinationVector = _destination.transform.position;
                _navMeshAgent.SetDestination(targetDestinationVector);
            }
            else
                Debug.LogError("Destination is empty on " + this.gameObject);
        }
    }
}