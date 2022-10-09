using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RPG.Combat;
using RPG.Movment;

namespace RPG.Contorl
{
    public class PlayerContorler : MonoBehaviour
    {
        Mover mover;
        private void Start()
        {
          mover= GetComponent<Mover>();
        }
        void Update()
        {
            if(IntractWhitFighter()) return;
            if( IntractWhitMovment()) return;
            print("noting");
        }
        private bool IntractWhitFighter()
        {
            
                RaycastHit[] hits = Physics.RaycastAll(GetMousRay());
                foreach (RaycastHit hit in hits)
                {
                    CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                 if (target == null) continue;

                if (!GetComponent<Fighter>().CanAttake(target.gameObject)) continue;

                    if (Input.GetMouseButtonDown(0))
                    {
                        GetComponent<Fighter>().Attak(target.gameObject);
                    }
                return true;
            }
            return false;
        }
        private bool IntractWhitMovment()
        {
                RaycastHit hit;
                bool hasHit = Physics.Raycast(GetMousRay(), out hit);
               
                if (hasHit)
                {
                    if (Input.GetMouseButton(0))
                {
                        mover.StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
        }
        public static Ray GetMousRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}