using System;
using UnityEngine;

namespace Questions
{
    [Serializable]
    public class Answer
    {
        [SerializeField] private string answer;
        [SerializeField] private bool correct;
        
        public string AnswerString => answer;
        public bool Correct => correct;
    }
}