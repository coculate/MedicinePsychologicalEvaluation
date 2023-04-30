using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinePsychologicalEvaluation.Models
{

    /// <summary>
    /// 测评结果表
    /// </summary>
    public class Medicine_Record : BaseModel
    {
        public int UserId { get; set; }

        public int Score { get; set; }

        public int EvaluationId { get; set; }
    }
}
