using System.Collections.Generic;
using UnityEngine;

namespace Questions
{
    [CreateAssetMenu(fileName = "QuestionQueue", menuName = "Questions/QuestionQueue")]
    public class ScriptableQuestionQueue : ScriptableObject
    {
        [SerializeField] private List<ScriptableQuestion> questions;
        
        public List<ScriptableQuestion> Questions => questions;
    }
}