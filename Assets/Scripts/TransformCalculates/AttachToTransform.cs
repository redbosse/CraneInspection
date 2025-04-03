using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TransformCalculates
{
    public class AttachToTransform : MonoBehaviour
    {
        [SerializeField] private Transform attachTo;
        [SerializeField] private TypeOfUpdate type;
        [SerializeField] private float timerValue;
        [SerializeField] private Vector3 offset;

        private Transform targetTransform;
        private Coroutine coroutine = null;

        [Serializable]
        public enum TypeOfUpdate
        {
            timer,
            fixedUpdate,
            endOfFrame,
        }

        private void OnEnable()
        {
            if (coroutine == null)
            {
                coroutine = StartCoroutine(ControlableUpdate());
            }
            else
            {
                StopCoroutine(coroutine);
                coroutine = StartCoroutine(ControlableUpdate());
            }
        }

        private void OnDisable()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            else
            {
                coroutine = StartCoroutine(ControlableUpdate());
            }
        }

        private void Awake()
        {
            if (attachTo == null)
            {
                if (Camera.main != null) targetTransform = Camera.main.transform;

                if (targetTransform == null)
                {
                    throw new NullReferenceException();
                }
            }
            else
            {
                targetTransform = attachTo;
            }
        }
        
        private IEnumerator ControlableUpdate()
        {
            while (true)
            {
                transform.position = GetOffset();

                yield return type switch
                {
                    TypeOfUpdate.timer => new WaitForSeconds(timerValue),
                    TypeOfUpdate.fixedUpdate => new WaitForFixedUpdate(),
                    TypeOfUpdate.endOfFrame => new WaitForEndOfFrame(),
                    _ => null
                };
            }
        }

        private Vector3 GetOffset()
        {
            float height = offset.y;
            
            Vector2 forward2d = new Vector2(targetTransform.forward.x, targetTransform.forward.z).normalized * offset.z;
            
            return new Vector3(forward2d.x, height, forward2d.y) + targetTransform.position;
        }
    }
}

