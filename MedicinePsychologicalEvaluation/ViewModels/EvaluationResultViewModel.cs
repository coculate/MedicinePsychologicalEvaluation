using MedicinePsychologicalEvaluation.Models;
using MedicinePsychologicalEvaluation.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinePsychologicalEvaluation.ViewModels
{
    public class EvaluationResultViewModel : ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }

        public string UrlPathSegment { get; } = "/evaluationresult";

        private ObservableCollection<EvaluationResult> _items;

        public ObservableCollection<EvaluationResult> Items
        {
            get => _items;
            set => this.RaiseAndSetIfChanged(ref _items, value);
        }

        public EvaluationResultViewModel(IScreen screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            _items = new ObservableCollection<EvaluationResult>(CreateItems());
        }

        private List<EvaluationResult> CreateItems()
        {
            using (MyDbContext db = new MyDbContext())
            {
                if (db.Medicine_Record != null && db.Medicine_Evaluation != null)
                {
                    var evaluations = db.Medicine_Record
                    .Join(db.Medicine_Evaluation, a => a.EvaluationId, b => b.id, (a, b) => new EvaluationResult
                    {
                        EvaluationName = b.EvaluationName,
                        ResultId = a.id,
                        EvaluationTypeName = b.EvaluationTypeName,
                        UserName = GetSingleUser(a.UserId).UserName,
                        Score = a.Score
                    }).AsNoTracking();
                    return evaluations.ToList();
                }
                return new List<EvaluationResult>();
            }
        }

        public void RunTheThing(string parameter)
        {
            int.TryParse(parameter, out int resultId);
            using (MyDbContext db = new MyDbContext())
            {
                Medicine_Record record = db.Medicine_Record.Find(resultId);
                if (null != record)
                {
                    db.Medicine_Record.Remove(record);
                    int flag = db.SaveChanges();
                    if (flag > 0)
                    {
                        HostScreen.Router.Navigate.Execute(new EvaluationResultViewModel(HostScreen));
                    }
                }
            }
        }

    }
}
