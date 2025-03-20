using System;
using UnityEngine;

namespace ObjectPool
{
    public class XRPlayerInspector : MonoBehaviour
    {
        private void Start()
        {
            UniversalObjectPull.AddXRPlayerInspector(this);
        }
    }
}