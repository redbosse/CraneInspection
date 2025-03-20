using System;
using System.Collections.Generic;
using UnityEngine;

namespace Questions
{
    [Serializable]
    public class Quest
    {
        [Multiline][SerializeField] private string question;
        [SerializeField] private List<Answer> answers;
        
        public string Question => question;
        public List<Answer> Answers => answers;
        
    }
}