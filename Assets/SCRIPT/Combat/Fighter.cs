using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movment;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour , IAction
    {
        Health target;
        Mover mover;
       [SerializeField] int wapenRang = 2;
       [SerializeField] float timeBetweenAtaack;
       [SerializeField] float weapanDameg = 10;
       float timeSinceLastAttack=Mathf.Infinity;

        private void Start()
        {
            mover = GetComponent<Mover>();
            
        }

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;
            if (target.ISdead()) return;
            
                if (!GetIsInRang())
                {
                   GetComponent<ActionScheduler>().startAction(this); // cancel last event
                   mover.MoveTo(target.transform.position);      //move to enemy 
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
                transform.LookAt(target.transform.position);  //look at enemy  
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
            if (target == null) return;
            target.TakeDamge(weapanDameg);
        }
        private bool GetIsInRang()
        {
            return Vector3.Distance(transform.position, target.transform.position) < wapenRang;
        }

        public void Attak(GameObject target)
        {
            if (target == null) return;
            this.target = target.GetComponent<Health>();
            
        }
        public void CancelAttak()
        {
            target = null;
        }
        public void Cancel()
        {
            GetComponent<Animator>().ResetTrigger("Attake");
            GetComponent<Animator>().SetTrigger("stopAttake");
            target = null;
        }
       public bool CanAttake(GameObject combatTarget)
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

