using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;
using RPG.Core;

namespace RPG.Contorl
{
    public class AiContorler : MonoBehaviour,IAction
    {
        bool playerIsDead;
        [SerializeField] float chaseRange = 5;

        GameObject player;
        Fighter fighter;
        private void Awake()
        {
            player = GameObject.FindWithTag("Player");
            fighter = GetComponent<Fighter>();
        }

        private void Update()
        {
            if (InAttakeRangeOfPlayer() && fighter.CanAttake(player) &&!playerIsDead)
            {
                GetComponent<ActionScheduler>().startAction(this);
                fighter.Attak(player);
            }
            else
            {
                fighter.Cancel();
            }

          
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
        
    }
}
