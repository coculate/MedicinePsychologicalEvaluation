using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Notifications;
using MedicinePsychologicalEvaluation.Models;
using MedicinePsychologicalEvaluation.Views;
using ReactiveUI;

namespace MedicinePsychologicalEvaluation.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public static string Greeting => "ҽ���������ϵͳ";

        private INotificationManager? _notificationManager;
        public INotificationManager NotificationManager => _notificationManager
            ??= new WindowNotificationManager((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow);

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
