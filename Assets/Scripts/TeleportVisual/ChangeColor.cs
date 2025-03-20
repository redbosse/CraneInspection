using UnityEngine;

namespace TeleportVisual
{
    public class ChangeColor : MonoBehaviour
    {
        [SerializeField] private Color targetColor;
        [SerializeField] private MeshRenderer renderer;

        private Color bufferizedColor;

        public void Change()
        {
            bufferizedColor = renderer.material.color;
            renderer.material.color = targetColor;
        }
        
        public void ResetColor()
        {
            renderer.material.color = bufferizedColor;
        }
    }
}
