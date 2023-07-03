using Avalonia.Controls.Notifications;
using MedicinePsychologicalEvaluation.Models;
using MedicinePsychologicalEvaluation.Models.Enums;
using MedicinePsychologicalEvaluation.Views;
using ReactiveUI;
using Splat;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using Notification = Avalonia.Controls.Notifications.Notification;

namespace MedicinePsychologicalEvaluation.ViewModels
{
    public class UserInfoViewModel : ViewModelBase, IRoutableViewModel
    {

        #region 界面TextBox绑定值

        public Medicine_Users? CurrentUser
        {
            get => LoginUser;
            set => this.RaiseAndSetIfChanged(ref LoginUser, value);
        }

        #endregion

        public IScreen HostScreen { get; }

        public string? UrlPathSegment { get; } = LoginUser?.UserAccount;

        public UserInfoViewModel()
        {

        }

        public UserInfoViewModel(IScreen screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            //Items = new ObservableCollection<SelectItems>(
            //    Enumerable.Range(0, 20).Select(x => new SelectItems
            //    {
            //        Value = x,
            //        Text = "Item " + x + " Text",
            //    }));

            GenderItems = new ObservableCollection<SelectItems>(new List<SelectItems> {
            new SelectItems{ Value=((int)Sex.男),Text=Sex.男.ToString() },
            new SelectItems{ Value=((int)Sex.女),Text=Sex.女.ToString() },
            new SelectItems{ Value=((int)Sex.其它),Text=Sex.其它.ToString() }
            });

            EducationItems = new ObservableCollection<SelectItems>(new List<SelectItems> {
            new SelectItems{ Value=((int)Education.小学),Text=Education.小学.ToString() },
            new SelectItems{ Value=((int)Education.初中),Text=Education.初中.ToString() },
            new SelectItems{ Value=((int)Education.高中),Text=Education.高中.ToString() },
            new SelectItems{ Value=((int)Education.大专),Text=Education.大专.ToString() },
            new SelectItems{ Value=((int)Education.本科),Text=Education.本科.ToString() },
            new SelectItems{ Value=((int)Education.研究生),Text=Education.研究生.ToString() },
            new SelectItems{ Value=((int)Education.博士),Text=Education.博士.ToString() }
            });

            MarriageItems = new ObservableCollection<SelectItems>(new List<SelectItems> {
            new SelectItems{ Value=((int)Marriage.未婚),Text=Marriage.未婚.ToString() },
            new SelectItems{ Value=((int)Marriage.已婚),Text=Marriage.已婚.ToString() },
            new SelectItems{ Value=((int)Marriage.丧偶),Text=Marriage.丧偶.ToString() }
            });

            UpdateBtn = ReactiveCommand.Create(() =>
            {
                using (MyDbContext dbContext = new MyDbContext())
                {
                    if (null == CurrentUser)
                    {
                        DialogManage.Show(DialogType.TopCenter, "没有获取到用户");
                        return;
                    }
                    dbContext.Medicine_Users?.Update(CurrentUser);
                    int flag = dbContext.SaveChanges();
                    if (flag > 0)
                    {
                        DialogManage.Show(DialogType.TopCenter, "更新成功");
                    }
                }
            });
        }

        public ReactiveCommand<Unit, Unit> UpdateBtn { get; }

        public ObservableCollection<SelectItems> GenderItems { get; }

        public ObservableCollection<SelectItems> EducationItems { get; }

        public ObservableCollection<SelectItems> MarriageItems { get; }

    }
}
