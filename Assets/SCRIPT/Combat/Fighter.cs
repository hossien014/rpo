using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movment;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour , IAction
    {
        Health targetEnemy;
        Mover mover;
       [SerializeField] int wapenRang = 2;
       [SerializeField] float timeBetweenAtaack;
       [SerializeField] float weapanDameg = 10;
       float timeSinceLastAttack;

        private void Start()
        {
            mover = GetComponent<Mover>();
        }

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (targetEnemy == null) return;
            if (targetEnemy.ISdead()) return;
            
                if (!GetIsInRang())
                {
                   GetComponent<ActionScheduler>().startAction(this); // cancel last event
                   
                   mover.MoveTo(targetEnemy.transform.position);      //move to enemy 
                    
                }
                else
                {
                    mover.Cancel();
                    AttackBehaviour();
                }
            
           
        }

        private void AttackBehaviour()
        {
            if (timeSinceLastAttack > timeBetweenAtaack)
            {
                transform.LookAt(targetEnemy.transform.position);  //look at enemy  
                TrigerAttack();
                timeSinceLastAttack = 0;
            }
        }

        private void TrigerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttake");
            GetComponent<Animator>().SetTrigger("Attake");
        }

        // Hit is Animation event
        void Hit()
        {
            //my changes 
            if (targetEnemy == null) return;
            targetEnemy.TakeDamge(weapanDameg);
        }
        private bool GetIsInRang()
        {
            return Vector3.Distance(transform.position, targetEnemy.transform.position) < wapenRang;
        }

        public void Attak(CombatTarget target)
        {

            targetEnemy = target.GetComponent<Health>();
            
        }
        public void CancelAttak()
        {
            targetEnemy = null;
        }
        public void Cancel()
        {
            GetComponent<Animator>().ResetTrigger("Attake");
            GetComponent<Animator>().SetTrigger("stopAttake");
            targetEnemy = null;
           
        }
       public bool CanAttake(CombatTarget combatTarget)
        {
            if (combatTarget == null) return false;
            Health targetToTest = combatTarget.GetComponent<Health>();

            return targetToTest!=null && !targetToTest.ISdead();

            // می توانیم از فالس و ترو برای ریترن استفاده کنیم ولی کاری که 
           // در مثال بالا انجام شده است  برسی کردن شرط است 
           // یعنی گفتیم که اگر تارگت  نال نبود و مرده نبود ترو برگردان
        }
       
    }

}

