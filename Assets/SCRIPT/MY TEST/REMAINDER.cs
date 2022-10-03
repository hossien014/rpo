using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REMAINDER : MonoBehaviour
{
    Ray ray;
    void Start()
    {

     
        print("ray.direction = " + ray.direction);
        int hash = ray.GetHashCode();
        print("HashCode = " + ray.GetHashCode());
        print("string =" + ray.ToString());
        print("orging =" + ray.origin);
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
      bool hashit= Physics.Raycast(ray.origin,ray.direction*100,out hit);
        if (hashit) { print(hit.transform.name);     }
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red,1f);

    }
}
