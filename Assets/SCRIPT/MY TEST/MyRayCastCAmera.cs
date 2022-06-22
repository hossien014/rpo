using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRayCastCAmera : MonoBehaviour
{
    RaycastHit hit;
    Vector3 targetPositon;
    
    void Update()
    {
        Physics.Raycast(transform.position, transform.forward, out hit);
         targetPositon = hit.transform.position;
    }
    public Vector3 GetTargetPOsiton()
    {
        return targetPositon;
    }
   

}
