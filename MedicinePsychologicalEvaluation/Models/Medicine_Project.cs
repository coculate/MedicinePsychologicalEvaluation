using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinePsychologicalEvaluation.Models
{

    /// <summary>
    /// 问题答案表
    /// </summary>
    public class Medicine_Project : BaseModel
    {
        public int EvaluationId { get; set; }

        public string? Title { get; set; }

        public string? AnswerA { get; set; }

        public string? AnswerB { get; set; }

        public string? AnswerC { get; set; }

        public string? AnswerD { get; set; }

        public string? Answer { get; set; }

        public int ScoreA { get; set; }

        public int ScoreB { get; set; }

        public int ScoreC { get; set; }

        public int ScoreD { get; set; }

        public int UserId { get; set; }

    }
}
