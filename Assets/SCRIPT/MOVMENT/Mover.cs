
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
        
        NavMeshAgent navmesh;
        Animator animator;
        Health health;
        
        void Start()
        {
            health=GetComponent<Health>();
            navmesh = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            navmesh.autoRepath = true;
        }
       

        void Update()
        {
            navmesh.enabled = !health.ISdead();
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
            navmesh.isStopped = false;
            navmesh.destination = destenation;
        }
       
        private void UpdatAnimation()
        {
            var LocalPvlocity = transform.InverseTransformDirection(navmesh.velocity);
            float speed = LocalPvlocity.z;
            animator.SetFloat("forwardspeed", speed);

        }
        public void Cancel()
        {
            if(navmesh.enabled=true)
            navmesh.isStopped = true;
        }
    }
}
