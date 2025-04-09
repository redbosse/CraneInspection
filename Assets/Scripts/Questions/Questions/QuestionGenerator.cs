using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Questions
{
    public class QuestionGenerator : MonoBehaviour
    {
        [SerializeField] private UnityEvent<string> OnEndQuestions;
        [SerializeField] private UnityEvent<string> OnQuestResponse;

        [SerializeField] private ScriptableQuestionQueue questions;
        [SerializeField] private GameObject questionPrefab;
        [SerializeField] private TMP_Text headerText;

        private ScriptableQuestion currentQuestion;

        private int currentQuestionIndex;
        private int finalScore;

        private readonly List<GameObject> questionsPool = new();

        private void Start()
        {
            if (questions.Questions.Count == 0)
                return;

            currentQuestion = questions.Questions[currentQuestionIndex];

            Generate(currentQuestion);
        }

        public void Generate(ScriptableQuestion question)
        {
            headerText.text = question.GetQuest.Question;

            foreach (var item in question.GetQuest.Answers)
            {
                var scriptableQuestion = Instantiate(questionPrefab, transform);
                scriptableQuestion.GetComponent<ResponseToggle>().SetAnswer(item);

                questionsPool.Add(scriptableQuestion);
            }
        }

        public void Reply()
        {
            int correctCount = GetRightAnswersCount();
            OnQuestResponse?.Invoke(correctCount.ToString());

            LigthUpTheRigthQuestions();

            finalScore += correctCount;
        }

        public void Next()
        {
            currentQuestionIndex++;

            if (OnEndQuest(currentQuestionIndex)) OnEndQuestions.Invoke(finalScore.ToString());

            if (!ValidateIndex(currentQuestionIndex)) return;

            currentQuestion = questions.Questions[currentQuestionIndex];

            ClearPool();
            Generate(currentQuestion);
        }

        private bool ValidateIndex(int index)
        {
            return index >= 0 && index < questions.Questions.Count;
        }

        private bool OnEndQuest(int index)
        {
            return index >= questions.Questions.Count;
        }

        private int GetRightAnswersCount()
        {
            var rightCount = 0;

            foreach (var item in questionsPool)
            {
                var answer = item.GetComponent<ResponseToggle>();

                rightCount += answer.GetScore();
            }

            return rightCount;
        }

        private void LigthUpTheRigthQuestions()
        {
            foreach (var item in questionsPool)
            {
                var answer = item.GetComponent<ResponseToggle>();
                answer.LightUp();
            }
        }

        private void ClearPool()
        {
            foreach (var item in questionsPool) Destroy(item);

            questionsPool.Clear();

            finalScore = 0;
        }
    }
}