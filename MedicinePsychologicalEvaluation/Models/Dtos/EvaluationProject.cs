namespace MedicinePsychologicalEvaluation.Models.Dtos
{
    public class EvaluationProject
    {
        public int EvaluationId { get; set; }

        public int ProjectId { get; set; }

        public string? EvaluationName { get; set; }

        public string? Title { get; set; }

        public string? AnswerA { get; set; }

        public string? AnswerB { get; set; }

        public string? AnswerC { get; set; }

        public string? AnswerD { get; set; }

        public string? Answer { get; set; }

        public int Score { get; set; }
    }
}
