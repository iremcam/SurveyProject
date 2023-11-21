using SurveyProject.Models;
using SurveyProject.Models.DTOs;

namespace SurveyProject.Business
{
    public class QuestionBl
    {
        SurveyProjectContext Context = new SurveyProjectContext();

        public List<Question> GetQuestionList( int surveyId)
        {
            

            List<Question> list = Context.Question.Where(a=>a.SurveyId==surveyId).ToList();
            return list;
        }
        
        public bool CreateQuestion(Question question)
        {
            question.Id = 0;
            int maxOrder = Context.Question.Max(q => q.Order);
            question.Order = maxOrder + 1;
           
            Context.Question.Add(question);

            Context.SaveChanges();


            int questionId = question.Id;

            // Optionları oluşturun ve soruya bağlayın
            Option option1 = new Option { QuestionId = questionId, Name = "Katılıyorum" };
            Option option2 = new Option { QuestionId = questionId, Name = "Kısmen" };
            Option option3 = new Option { QuestionId = questionId, Name = "Katılmıyorum" };

            Context.Option.AddRange(option1, option2, option3);
            Context.SaveChanges();
            return true;
        }

        //anket soruları
        public SolutionDTO  BringtheQuestion( int assignmentId,int userId)
        {
            Assignment assignment = Context.Assignment.FirstOrDefault(a => a.UserId == userId);
            List<Question> questions=Context.Question.Where(a=>a.SurveyId== assignmentId).ToList();
            foreach (var question in questions)
            {
                question.Options = Context.Option.Where(o => o.QuestionId == question.Id).ToList();
            }

            SolutionDTO dto = new SolutionDTO();
            dto.SurveyId = assignment.SurveyId;
            dto.Questions = questions;
            return dto;

        }


    }
}
