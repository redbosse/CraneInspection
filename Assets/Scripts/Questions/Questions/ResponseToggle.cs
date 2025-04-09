using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Questions
{
    public class ResponseToggle:MonoBehaviour
    {
        [SerializeField] private Toggle toggle;
        [SerializeField] private TMP_Text text;
        [SerializeField] private Image image;
        [SerializeField] private Color trueColor = Color.green;
        [SerializeField] private Color falseColor = Color.red;
        
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

        public void CleanLigthUp()
        {
            image.enabled = false;
        }

        public int GetScore()
        {
            return IsAnswerCorrect() ? answer.ScoreCorrect : answer.ScoreUncorrect;
        }

        public void LightUp()
        {
            image.enabled = true;
            image.color = answer.Correct ? trueColor : falseColor;
            toggle.interactable = false;
        }
    }
}