using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MonobehaviourXRExtensions
{
  public static float DistanceTo(this Transform transform, Vector3 point)
  {
    return Vector3.Distance(transform.position, point);
  }
}
