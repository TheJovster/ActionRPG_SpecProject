using System;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class PlayerMotor : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void SetDestination(Vector3 destination)
        {
            if (_navMeshAgent.isStopped)
            {
                _navMeshAgent.isStopped = false;
            }
            _navMeshAgent.SetDestination(destination);
        }

        public void StopMovement()
        {
            _navMeshAgent.isStopped = true;
            _navMeshAgent.velocity = Vector3.zero;
        }
    }
}

