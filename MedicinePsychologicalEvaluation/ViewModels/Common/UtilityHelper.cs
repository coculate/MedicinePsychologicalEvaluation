using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinePsychologicalEvaluation.ViewModels.Common
{
    public class UtilityHelper
    {

        /// <summary>
        /// 通过分数获取诊断结果
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public static string GetTestResult(int score)
        {
            string result = "";
            if (score < 50)
            {
                result = $"得分：{score}；测试结果：无明显焦虑，无建议";
            }
            if (score >= 50 && score < 60)
            {
                result = $"得分：{score}；测试结果：轻度焦虑，建议聚焦注意力在每天饮食均衡、适当运动和保障睡眠上，只要做到了这三点，基本上轻度焦虑就能消失，尤其是保障睡眠。睡不着的话优先使用深呼吸法、4-7-8呼吸法，急于解决睡眠问题的话可以借助于食疗和非处方药";
            }
            if (score >= 60 && score < 70)
            {
                result = $"得分：{score}；测试结果：中度焦虑，建议请去三甲医院的精神科就诊";
            }
            if (score >= 70)
            {
                result = $"得分：{score}；测试结果：重度焦虑，建议请去三甲医院的精神科就诊";
            }
            return result;
        }

    }
}
