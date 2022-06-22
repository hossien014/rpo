using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    [ExecuteInEditMode]
    public class FollowCamra : MonoBehaviour
    {
        [SerializeField] Transform target;

        void Update()
        {
            transform.position = target.position;
        }
    }
}