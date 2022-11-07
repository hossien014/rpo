using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;
using RPG.Core;
using RPG.Movment;
using System;

namespace RPG.Contorl
{
    public class AiContorler : MonoBehaviour,IAction
    {
        bool playerIsDead;
        GameObject player;
        Fighter fighter;
        Mover mover;
        Health health;
        Vector3 gurdPosition;
        [SerializeField]PatrolPath patrolPath;

        [SerializeField] float WayPointTolerance = 1;
        [SerializeField] float chaseRange = 5;
        [SerializeField] float SuspactTime = 5;
        [SerializeField] float DwellingTime = 2;
        float timeSinceLastSawPlayer = Mathf.Infinity;
        float timeSinceArrivedAtWayPoint = Mathf.Infinity;
        int currentWayPointIndex=0;


        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            fighter = GetComponent<Fighter>();
            mover = GetComponent<Mover>();
            health = GetComponent<Health>();
            gurdPosition = transform.position;
        }
        private void Update()
        {
            if (health.ISdead()) return;
            if (InAttakeRangeOfPlayer() && fighter.CanAttake(player) && !playerIsDead)
            {
                AttackBehaviour();
            }
            else if (timeSinceLastSawPlayer < SuspactTime)
            {
                SuspicionBehavour();
            }
            else
            {
                PatrolBehaviour();
            }
            UpdateTimers();
        }

        private void UpdateTimers()
        {
            timeSinceLastSawPlayer += Time.deltaTime;
            timeSinceArrivedAtWayPoint += Time.deltaTime;
        }

        private void PatrolBehaviour()
        {
            Vector3 nextPosition = gurdPosition;
            if (patrolPath!=null)
            {
                if (AtWayPoint())
                {
                    timeSinceArrivedAtWayPoint = 0;
                    CycleWaypoint();
                  
                }
                nextPosition = GetCurrentWayPoiny();
            }
            if(timeSinceArrivedAtWayPoint > DwellingTime)
            {
            mover.StartMoveAction(nextPosition);
            }
        }

        private bool AtWayPoint()
        {
            float distanceToWayPoint = Vector3.Distance(transform.position, GetCurrentWayPoiny());
            return distanceToWayPoint < WayPointTolerance;
        }

        private void CycleWaypoint()
        {
            currentWayPointIndex= patrolPath.GetNextWayPoint(currentWayPointIndex);
        }

        private Vector3 GetCurrentWayPoiny()
        {
            return patrolPath.GetWayPoint(currentWayPointIndex);
        }

        private void AttackBehaviour()
        {
            timeSinceLastSawPlayer = 0;
            fighter.Attak(player);
        }
        private void SuspicionBehavour()
        {
            GetComponent<ActionScheduler>().cancelCurrentAction();
        }
        public bool InAttakeRangeOfPlayer()
        {
            float PlayerDistance = Vector3.Distance(transform.position, player.transform.position);
            return PlayerDistance <= chaseRange;
        }
        public void Cancel()
        {
            playerIsDead = false;
            fighter.Cancel();
        }
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseRange);
        }
    }
}
