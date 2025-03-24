using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Questions
{
    public class ResponseToggle:MonoBehaviour
    {
        [SerializeField] private Toggle toggle;
        [SerializeField] private TMP_Text text;
        
        private Answer answer;

        public void SetAnswer(Answer initAnswer)
        {
            answer = initAnswer;
            text.text = answer.AnswerString;
        }

        public bool IsAnswerCorrect()
        {
            return answer.Correct && toggle.isOn;
        }
    }
}