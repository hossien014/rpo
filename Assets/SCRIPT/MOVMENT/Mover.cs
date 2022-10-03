
using RPG.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



namespace RPG.Movment
{
    public class Mover : MonoBehaviour ,IAction
    {
        
        NavMeshAgent Charctor;
        Animator animator;
        
        void Start()
        {
            
            Charctor = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            Charctor.autoRepath = true;
        }

        void Update()
        {

            UpdatAnimation();
        }

        public void StartMoveAction(Vector3 destenation)
        {
            GetComponent<ActionScheduler>().startAction(this);
           // GetComponent<Fighter>().CancelAttak();
            MoveTo(destenation);
        }
        public void MoveTo(Vector3 destenation)
        {
            // i change this for player to charctor
            Charctor.isStopped = false;
            Charctor.destination = destenation;
        }
       
        private void UpdatAnimation()
        {
            var LocalPvlocity = transform.InverseTransformDirection(Charctor.velocity);
            float speed = LocalPvlocity.z;
            animator.SetFloat("forwardspeed", speed);

        }
        public void Cancel()
        {
            Charctor.isStopped = true;
        }
    }
}
