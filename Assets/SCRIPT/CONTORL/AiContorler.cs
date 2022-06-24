using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movment;
using RPG.Combat;

namespace RPG.Contorl
{

    public class AiContorler : MonoBehaviour
    {
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
            if (InAttakeRangeOfPlayer() && fighter.CanAttake(player))
            {
                fighter.Attak(player);
            }

          
        }
        public bool InAttakeRangeOfPlayer()
        {
            float PlayerDistance = Vector3.Distance(transform.position, player.transform.position);
            return PlayerDistance <= chaseRange;
        }
        
        
    }
}
