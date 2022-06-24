using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : Charctor
{
    
  public override  void  takeDamege (int damge)
    {
       base. takeDamege(damge * 50);
    }
}
