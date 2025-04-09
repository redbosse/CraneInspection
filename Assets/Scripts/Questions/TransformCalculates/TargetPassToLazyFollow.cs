using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.UI;

namespace TransformCalculates
{
    public class TargetPassToLazyFollow : MonoBehaviour
    {
        [SerializeField] private Transform lazyTarget;
        [SerializeField] private LazyFollow lazyFollow;
     
        void Start()
        {
            if (lazyFollow == null)
            {
                throw new System.ArgumentNullException("lazyFollow");
            }

            if (lazyTarget == null)
            {
                lazyTarget = LazyTarget.target;
                
                if (lazyTarget == null)
                    throw new System.ArgumentNullException("target");
            }
            
            lazyFollow.target = lazyTarget.transform;
        }
        
    }
}
