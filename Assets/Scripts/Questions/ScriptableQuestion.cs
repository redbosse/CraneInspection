using UnityEngine;

namespace Questions
{
    [CreateAssetMenu(fileName = "Question", menuName = "Questions/Question")]
    public class ScriptableQuestion : ScriptableObject
    {
        [SerializeField] private Quest quest;
    }
}