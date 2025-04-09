using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Crouch
{
   public class XRCrouch : MonoBehaviour
   {
      [SerializeField] private XROrigin origin;
      [SerializeField] private InputActionReference crouchAction;
      [SerializeField] private float crouchYOffset;
      [SerializeField] private float stayYOffset;
      
      private bool isCrouching = true;

      private void OnEnable()
      {
         origin.CameraYOffset = stayYOffset;
         
         crouchAction.action.performed += Crouch;
      }

      private void OnDisable()
      {
         crouchAction.action.performed -= Crouch;
      }
      
      private void Crouch(InputAction.CallbackContext obj)
      {
         if (isCrouching)
         {
            origin.CameraYOffset = crouchYOffset;
            
            isCrouching = false;
         }
         else
         {
            origin.CameraYOffset = stayYOffset;
            
            isCrouching = true;
         }
      }
   }
}
