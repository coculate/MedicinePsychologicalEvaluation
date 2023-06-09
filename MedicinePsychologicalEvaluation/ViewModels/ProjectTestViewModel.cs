﻿using MedicinePsychologicalEvaluation.Models;
using MedicinePsychologicalEvaluation.Models.Dtos;
using MedicinePsychologicalEvaluation.ViewModels.Common;
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

        /// <summary>
        /// 检测结果
        /// </summary>
        public string TestResult
        {
            get => testResult;
            set => this.RaiseAndSetIfChanged(ref testResult, value);
        }

        private string borderBg;

        /// <summary>
        /// 背景色
        /// </summary>
        public string BoderBg
        {
            get => borderBg;
            set => this.RaiseAndSetIfChanged(ref borderBg, value);
        }

        private ObservableCollection<ItemMain> _items;

        public ObservableCollection<ItemMain> Items
        {
            get => _items;
            set => this.RaiseAndSetIfChanged(ref _items, value);
        }

        public ProjectTestViewModel()
        { 
        
        }

        public ProjectTestViewModel(IScreen screen, int evaluationId)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            _items = new ObservableCollection<ItemMain>(GetItems(evaluationId));
            testResult = "";
            borderBg = "Red";
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
                var evaluations = db.Medicine_Project.Where(t => t.EvaluationId == evaluationId).AsNoTracking().AsEnumerable()
                    .Select((t, i) => new ItemMain
                    {
                        id = t.id,
                        Rows = (i + 1),
                        EvaluationId = t.EvaluationId,
                        Title = t.Title,
                        Answer = t.Answer,
                        Background = "Red",
                        ItemChilds = new List<ItemChild> {
                            new ItemChild{ IsCheck=false,parentId=t.id,SelectOption=t.AnswerA,Score=t.ScoreA},
                            new ItemChild{ IsCheck=false,parentId=t.id,SelectOption=t.AnswerB,Score=t.ScoreB},
                            new ItemChild{ IsCheck=false,parentId=t.id,SelectOption=t.AnswerC,Score=t.ScoreC},
                            new ItemChild{ IsCheck=false,parentId=t.id,SelectOption=t.AnswerD,Score=t.ScoreD}
                        }
                    }) ;

                return evaluations.ToList();
            }
        }

        public ReactiveCommand<Unit, Unit> OkBtn { get; }

        public void ChangeBackGround(string parameter)
        {
            int.TryParse(parameter, out int resultId);
            ItemMain item = Items.FirstOrDefault(t => t.id == resultId);
            if (item != null)
            {
                ItemChild children = item.ItemChilds.FirstOrDefault(t => t.IsCheck && t.parentId == item.id);
                if (null == children)
                {
                    return;
                }
                item.Background = "Green";
            }
        }

        private void RunTheThing()
        {
            // 分数计算
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
                score += children.Score;
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
                    HostScreen.Router.Navigate.Execute(new ShowResultViewModel(HostScreen, score));
                }
            }

        }

    }
}
