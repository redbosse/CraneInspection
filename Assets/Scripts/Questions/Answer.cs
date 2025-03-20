using System;
using UnityEngine;

namespace Questions
{
    [Serializable]
    public class Answer
    {
        [SerializeField] private string answer;
        [SerializeField] private bool correct;
    }
}