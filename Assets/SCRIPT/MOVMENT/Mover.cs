using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movment
{
    public class Mover : MonoBehaviour
    {
        NavMeshAgent player;
        Animator animator;

        void Start()
        {
            player = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            UpdatAnimation();
        }


        public void MoveTo(Vector3 destenation)
        {
            player.destination = destenation;
        }
        private void UpdatAnimation()
        {
            var LocalPvlocity = transform.InverseTransformDirection(player.velocity);
            float speed = LocalPvlocity.z;
            animator.SetFloat("forwardspeed", speed);

        }
    }
}
