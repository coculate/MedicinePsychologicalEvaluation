using MedicinePsychologicalEvaluation.Models.Enums;
using System;

namespace MedicinePsychologicalEvaluation.Models
{

    /// <summary>
    /// 测评主表
    /// </summary>
    public class Medicine_Evaluation : BaseModel
    {
        public int UserId { get; set; }

        public string? EvaluationName { get; set; }

        public EvaluationType EvaluationType { get; set; }

        public int Score { get; set; }

        public string? EvaluationTypeName {
            get {
                string? name = Enum.GetName(EvaluationType); ;
                return name;
            }
        }

    }
}
