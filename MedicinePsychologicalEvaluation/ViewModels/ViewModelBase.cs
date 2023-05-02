using MedicinePsychologicalEvaluation.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicinePsychologicalEvaluation.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public static string Greeting => "ҽ����������ϵͳ";

        public static Medicine_Users? LoginUser;

        /// <summary>
        /// ͨ���û�id��ȡ�����û�����
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