using MedicinePsychologicalEvaluation.Models.Enums;

namespace MedicinePsychologicalEvaluation.Models
{

    /// <summary>
    /// 用户表
    /// </summary>
    public class Medicine_Users : BaseModel
    {
        public string? UserAccount { get; set; }

        public string? UserPwd { get; set; }

        public string? UserName { get; set; }

        public Sex UserGander { get; set; }

        public int UserAge { get; set; }

        public Education Education { get; set; }

        public Marriage Marriage { get; set; }

        public int UserType { get; set; }

    }
}
