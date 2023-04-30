namespace MedicinePsychologicalEvaluation.Models.Dtos
{
    public class EvaluationResult
    {
        public int ResultId { get; set; }

        public string? EvaluationName { get; set; }

        public string? EvaluationTypeName { get; set; }

        public string? UserName { get; set; }

        public int Score { get; set; }
    }
}
