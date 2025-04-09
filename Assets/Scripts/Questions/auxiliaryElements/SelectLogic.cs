using System.Collections;
using System.Collections.Generic;
using ObjectPool;
using UnityEngine;
using UnityEngine.Events;

public class SelectLogic : MonoBehaviour
{
   [SerializeField] private UnityEvent OnSelected;
   [SerializeField] private float plankOfDistance;
   
   public void OnSelect()
   {
      if (transform.DistanceTo(UniversalObjectPull.PlayerInspector.transform.position) < plankOfDistance)
      {
         OnSelected?.Invoke();
      }
   }
}
