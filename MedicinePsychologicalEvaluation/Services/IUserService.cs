using MedicinePsychologicalEvaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinePsychologicalEvaluation.Services
{
    public interface IUserService
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Register(Medicine_Users user);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Medicine_Users Login(Medicine_Users user);

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <returns></returns>
        Medicine_Users GetSingle(int id);

        /// <summary>
        /// 根据关键字获取所有数据
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        IEnumerable<Medicine_Users> GetUsers(string keyword);

        /// <summary>
        /// 删除用户数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 更改用户数据
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Medicine_Users ModifyUser(Medicine_Users user);


    }
}
