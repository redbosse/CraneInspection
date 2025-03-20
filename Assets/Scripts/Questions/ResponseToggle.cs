using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Questions
{
    public class ResponseToggle:MonoBehaviour
    {
        [SerializeField] private Toggle toggle;
        [SerializeField] private TMP_Text text;

        public void initialize(bool isSelect, TMP_Text text)
        {
        }
    }
}