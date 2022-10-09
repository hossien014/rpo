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

        Vector3 gaurdPositon;

        [SerializeField] float chaseRange = 5;
        [SerializeField] float SuspactTime = 5;
        float timeSinceLastSawPlayer = Mathf.Infinity;


        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            fighter = GetComponent<Fighter>();
            mover = GetComponent<Mover>();
            health = GetComponent<Health>();
            gaurdPositon = transform.position;
        }
        private void Update()
        {
            if (health.ISdead()) return;
            if (InAttakeRangeOfPlayer() && fighter.CanAttake(player) &&!playerIsDead)
            {
                AttackBehaviour();
                timeSinceLastSawPlayer = 0;
            }
            else if (timeSinceLastSawPlayer < SuspactTime)
            {
                SuspicionBehavour();
            }
            else
            {
                GuroudBehaviour();
            }
            timeSinceLastSawPlayer += Time.deltaTime;
        }
        private void AttackBehaviour()
        {
            fighter.Attak(player);
        }
        private void SuspicionBehavour()
        {
            GetComponent<ActionScheduler>().cancelCurrentAction();
        }
        private void GuroudBehaviour()
        {
            mover.StartMoveAction(gaurdPositon);
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
