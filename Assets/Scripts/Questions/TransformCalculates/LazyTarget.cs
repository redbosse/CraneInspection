using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyTarget : MonoBehaviour
{
    public static Transform _target;

    public static Transform target
    {
        get => _target;
        set => _target = value;
    }

    void Awake()
    {
        if (_target == null)
            target = transform;
    }
}
