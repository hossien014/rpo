
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
        
        bool IsDead=false;
       [SerializeField] float health = 100;

        public bool ISdead()
        {
            return IsDead;
        }
      public void TakeDamge(float damge)
        {
            
            health = Mathf.Max(health - damge, 0);
            print(health );
            if (health == 0 )
            {
                Die();
            }
          
        }

        private void Die()
        {
            if (IsDead) return;
            IsDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().cancelCurrentAction();

        }
    }

}
