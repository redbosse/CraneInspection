using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactors.Visuals;

namespace Interactable
{
    public class TeleportInteractable : XRBaseInteractable,IXRReticleDirectionProvider
    {
        public void GetReticleDirection(IXRInteractor interactor, Vector3 hitNormal, out Vector3 reticleUp,
            out Vector3? optionalReticleForward)
        {
            reticleUp = Vector3.up;
            optionalReticleForward = null;
            
            Debug.Log("Interract");
        }
    }
}
