using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SurveyProject.Models
{
    public abstract class Base
    {
       
        public int Id { get; set; }
    }
}
