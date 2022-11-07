using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Contorl
{
 public class PatrolPath : MonoBehaviour
 {
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1,0.3f,0,0.7f);
            for (int i = 0; i < transform.childCount; i++)
            {
               int j = GetNextWayPoint(i);
                Gizmos.DrawSphere(GetWayPoint(i), 0.3f);
                Gizmos.DrawLine(GetWayPoint(i), GetWayPoint(j));

            }

        }
        public  int GetNextWayPoint(int i)
        {
            if (i + 1 == transform.childCount)
            {
                return 0;
            }
            return i+1; 
        }
        public Vector3 GetWayPoint(int i)
        {
            return transform.GetChild(i).transform.position;
        }
    }

}
