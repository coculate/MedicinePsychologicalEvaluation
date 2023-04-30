using MedicinePsychologicalEvaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinePsychologicalEvaluation.Services
{
   public interface IProjectService
    {
        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <returns></returns>
        Medicine_Project GetSingle(int id);

        /// <summary>
        /// 根据关键字获取所有数据
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        IEnumerable<Medicine_Project> GetProjects(string keyword);

        /// <summary>
        /// 删除用户数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        bool InsertProject(Medicine_Project project);

        /// <summary>
        /// 更改数据
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        bool UpdateProject(Medicine_Project project);

    }
}
