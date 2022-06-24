using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class damegdealer :MonoBehaviour
{
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dealDamegToNearstCharctor();
        }
    }

    private void dealDamegToNearstCharctor()
    {
        Charctor nearestCharctor =
         FindObjectsOfType<Charctor>()
         .OrderBy(t =>
         Vector3.Distance(transform.position, t.transform.position)).FirstOrDefault();

        int damge = 1;

      //  if (nearestCharctor is npc) damge *= 5;

        nearestCharctor.takeDamege(damge);

        
         

    }
}
