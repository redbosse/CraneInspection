using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Questions
{
    public class QuestionGenerator : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnEndQuestions;
        [SerializeField] private UnityEvent<int> OnQuestResponce;
        
        [SerializeField] private ScriptableQuestionQueue questions;
        [SerializeField] private GameObject questionPrefab;
        [SerializeField] private TMP_Text headerText;

        private List<GameObject> questionsPool = new();
        private ScriptableQuestion currentQuestion;
        private int currentQuestionIndex = 0;
        
        public void Generate(ScriptableQuestion question)
        {
            headerText.text = question.GetQuest.Question;
            
            foreach (var item in question.GetQuest.Answers)
            {
                var scriptableQuestion = Instantiate(questionPrefab, transform) as GameObject;
                scriptableQuestion.GetComponent<ResponseToggle>().SetAnswer(item);
                
                questionsPool.Add(scriptableQuestion);
            }
        }

        public void Next()
        {
            currentQuestionIndex++;

            if (OnEndQuest(currentQuestionIndex))
            {
                OnEndQuestions.Invoke();
            }

            if (!ValidateIndex(currentQuestionIndex))
            {
                return;
            }

            currentQuestion = questions.Questions[currentQuestionIndex];

            int correctCount = GetRightAnswersCount();
            Debug.Log(correctCount);
            OnQuestResponce?.Invoke(correctCount);
            
            ClearPool();
            Generate(currentQuestion);
            
        }
        
        private void Start()
        {
            if(questions.Questions.Count == 0)
                return;
            
            currentQuestion = questions.Questions[currentQuestionIndex];
            
            Generate(currentQuestion);
        }
        
        private bool ValidateIndex(int index) => index >= 0 && index < questions.Questions.Count;

        private bool OnEndQuest(int index) => index >= questions.Questions.Count;

        private int GetRightAnswersCount()
        {
            int rightCount = 0;
            
            foreach (var item in questionsPool)
            {
                var answer = item.GetComponent<ResponseToggle>();
                
                if (answer.IsAnswerCorrect())
                {
                    rightCount++;
                }
                else
                {
                    rightCount--;
                }
            }
            
            return rightCount;
        }

        private void ClearPool()
        {
            foreach (var item in questionsPool)
            {
                Destroy(item);
            }
            
            questionsPool.Clear();
        }
    }
}
