using UnityEngine;

namespace TeleportVisual
{
    public class ChangeColor : MonoBehaviour
    {
        [SerializeField] private MeshRenderer renderer;
        [SerializeField] private string colorName;
        
        public void SetColor(Color color)
        {
            var oldColor = renderer.material.GetColor(colorName);
            renderer.material.SetColor(colorName, color);
        }
    }
}
