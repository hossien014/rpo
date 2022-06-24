using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charctor : MonoBehaviour
{
  public  int maxHealth = 100;
     public int currentHealth;
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void  takeDamege(int damge)
    {

        currentHealth -= damge;
        print("parent");

    }
}
