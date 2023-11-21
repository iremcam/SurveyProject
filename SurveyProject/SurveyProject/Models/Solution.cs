using SurveyProject.Business;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SurveyProject.Models
{
    public partial class Solution
    {
        //public virtual Survey? Survey { get; set; }
        //public virtual Question? Question { get; set; }
        //public virtual User? User { get; set; }
        //public virtual Option? Option { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public int OptionId { get; set; }
        public List<Question> SurveyQuestions { get; set; }
        [NotMapped]
        public Dictionary<int, List<Option>> UserAnswers { get; set; }


        

    }
}
