using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Project_Report.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public int GetQuestionCount()
        {
            return Answers == null ? 0 : Answers.Count();
        }
        public int GetAnswerCount()
        {
            return Answers == null ? 0 : Answers.Sum(c => c.Score);
        }

        public double CalculateScore()
        {
            int questions = GetQuestionCount();
            int contents = GetAnswerCount();

            return (questions ==0 || contents == 0) ? 0.0 : ((double)contents / (double)questions);
        }


    }
}