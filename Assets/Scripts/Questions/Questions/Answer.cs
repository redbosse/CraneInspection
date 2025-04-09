using System;
using UnityEngine;

namespace Questions
{
    [Serializable]
    public class Answer
    {
        [SerializeField] private string answer;
        [SerializeField] private bool correct;
        [SerializeField] private int scoreCorrect;
        [SerializeField] private int scoreUncorrect;
        
        public string AnswerString => answer;
        public bool Correct => correct;
        public int ScoreCorrect => scoreCorrect;
        public int ScoreUncorrect => scoreUncorrect;
    }
}