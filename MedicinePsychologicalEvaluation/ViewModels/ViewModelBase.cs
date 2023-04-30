using MedicinePsychologicalEvaluation.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicinePsychologicalEvaluation.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public static string Greeting => "医疗心理测评系统";

        public static Medicine_Users? LoginUser;

        /// <summary>
        /// 通过用户id获取单个用户数据
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        protected static Medicine_Users GetSingleUser(int userId)
        {
            Medicine_Users user = new Medicine_Users();
            using (MyDbContext db = new MyDbContext())
            {
                if (null != db.Medicine_Users)
                {
                    user = db.Medicine_Users.Find(userId);
                }
                return user;
            }
        }

    }
}
