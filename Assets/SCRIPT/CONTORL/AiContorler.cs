using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movment;

namespace RPG.Contorl
{

    public class AiContorler : MonoBehaviour
    {
        [SerializeField] float chaseRange = 5;

        GameObject player;
        private void Awake()
        {
            player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            chaseEnemy();
        }
        public void chaseEnemy()
        {
            float PlayerDistance = Vector3.Distance(transform.position, player.transform.position);
            if (PlayerDistance <= chaseRange)
            {
                GetComponent<Mover>().MoveTo(player.transform.position);
            }
        }
        
        
    }
}
