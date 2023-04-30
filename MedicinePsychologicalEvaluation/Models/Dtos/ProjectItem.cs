using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinePsychologicalEvaluation.Models.Dtos
{
    public class ProjectItem
    {
        public int id { get; set; }

        public int EvaluationId { get; set; }

        public string? Title { get; set; }

        public string? AnswerA { get; set; }

        public string? AnswerB { get; set; }

        public string? AnswerC { get; set; }

        public string? AnswerD { get; set; }

        public string? Answer { get; set; }

        public bool IsCheck { get; set; }

    }

}
