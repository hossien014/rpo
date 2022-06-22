using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movment;
namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        Transform targetEnemy; 

        private void Update()
        {
            if (targetEnemy != null)
            {
              //  GetComponent<Mover>().MoveTo(targetEnemy.position);

            }
        }
        public void Attak(CombatTarget target)
        {
            targetEnemy = target.transform;
            
        }

    }

}

