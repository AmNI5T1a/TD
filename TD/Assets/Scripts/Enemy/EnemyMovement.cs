using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace TD_game
{
    public enum TransitionParameters
    {
        Move,
        Idle,
        Death,
        Attack
    }
    public class EnemyMovement : MonoBehaviour
    {
        [Header("References: ")]

        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _enemyAnimator;


        [Header("In game references: ")]
        [Tooltip("After GameObject instanciation, script will try to find destination or shows an error")] [SerializeField] private GameObject _destination;

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
                Debug.LogError("Doesn't found object with tag");
        }

        void SetDestination()
        {
            if (_destination != null)
            {
                Vector3 targetDestinationVector = _destination.transform.position;
                _navMeshAgent.SetDestination(targetDestinationVector);
                _enemyAnimator.SetBool(TransitionParameters.Move.ToString(), true);
            }
            else
                Debug.LogError("Destination is empty on " + this.gameObject);
            _enemyAnimator.SetBool(TransitionParameters.Move.ToString(), false);
        }
    }
}