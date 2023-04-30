using MedicinePsychologicalEvaluation.Models;
using MedicinePsychologicalEvaluation.Models.Dtos;
using MedicinePsychologicalEvaluation.Views;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using Splat;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;

namespace MedicinePsychologicalEvaluation.ViewModels
{
    public class ProjectTestViewModel : ViewModelBase, IRoutableViewModel
    {

        public IScreen HostScreen { get; }

        public string UrlPathSegment { get; set; } = "/projecttest";

        private string testResult;

        public string TestResult
        {
            get => testResult;
            set => this.RaiseAndSetIfChanged(ref testResult, value);
        }

        private ObservableCollection<ItemMain> _items;

        public ObservableCollection<ItemMain> Items
        {
            get => _items;
            set => this.RaiseAndSetIfChanged(ref _items, value);
        }

        public ProjectTestViewModel(IScreen screen, int evaluationId)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            _items = new ObservableCollection<ItemMain>(GetItems(evaluationId));
            testResult = "";
            OkBtn = ReactiveCommand.Create(RunTheThing);
        }

        private List<Medicine_Project> CreateItems(int evaluationId)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var evaluations = db.Medicine_Project.Where(t => t.EvaluationId == evaluationId).AsNoTracking();
                return evaluations.ToList();
            }
        }

        private List<ItemMain> GetItems(int evaluationId)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var evaluations = db.Medicine_Project.Where(t => t.EvaluationId == evaluationId)
                    .Select(t => new ItemMain
                    {
                        id = t.id,
                        EvaluationId = t.EvaluationId,
                        Title = t.Title,
                        Answer = t.Answer,
                        ItemChilds = new List<ItemChild> {
                            new ItemChild{ IsCheck=false,parentId=t.id,SelectOption=t.AnswerA},
                            new ItemChild{ IsCheck=false,parentId=t.id,SelectOption=t.AnswerB},
                            new ItemChild{ IsCheck=false,parentId=t.id,SelectOption=t.AnswerC},
                            new ItemChild{ IsCheck=false,parentId=t.id,SelectOption=t.AnswerD}
                        }
                    })
                    .AsNoTracking();

                return evaluations.ToList();
            }
        }

        public ReactiveCommand<Unit, Unit> OkBtn { get; }

        private void RunTheThing()
        {
            // 分数，暂时分配为正确答案10分，其它5分，比重都为0.6
            int score = 0;
            StringBuilder tishi = new StringBuilder();
            for (int i = 0; i < Items.Count; i++)
            {
                ItemMain item = Items[i];
                ItemChild children = item.ItemChilds.FirstOrDefault(t => t.IsCheck && t.parentId == item.id);
                if (null == children)
                {
                    tishi.AppendFormat("第{0}题还没有选择，请选择\n", (i + 1));
                    continue;
                }
                if (children.SelectOption == item.Answer)
                {
                    score += 10;
                }
                else
                {
                    score += 5;
                }
            }
            if (!string.IsNullOrEmpty(tishi.ToString()))
            {
                DialogManage.Show(DialogType.TopCenter, tishi.ToString());
                return;
            }
            Medicine_Record record = new Medicine_Record
            {
                EvaluationId = Items[0].EvaluationId,
                UserId = null == LoginUser ? 0 : LoginUser.id,
                Score = score,
                CreateDate = System.DateTime.Now
            };

            using (MyDbContext db = new MyDbContext())
            {
                db.Medicine_Record?.Add(record);
                int flag = db.SaveChanges();
                if (flag > 0)
                {
                    if (score < 100)
                    {
                        TestResult = "测试结果：您是轻度患者，烦燥，坐立不安，神经过敏，紧张以及由此产生的躯体征象，如震颤等";
                    }
                    else
                    {
                        TestResult = "测试结果：您是重度患者，想象死亡，早醒，难以入睡等迹象，必要时可去看医生";
                    }
                }
            }

        }

    }
}
