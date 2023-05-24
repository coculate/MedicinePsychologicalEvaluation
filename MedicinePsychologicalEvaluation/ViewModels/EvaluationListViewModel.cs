using MedicinePsychologicalEvaluation.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MedicinePsychologicalEvaluation.ViewModels
{
    public class EvaluationListViewModel : ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }

        public string UrlPathSegment { get; } = "/evaluationlist";

        private ObservableCollection<Medicine_Evaluation> _items;

        public ObservableCollection<Medicine_Evaluation> Items {
            get => _items;
            set=>this.RaiseAndSetIfChanged(ref _items, value);
        }

        private string? _keyWord;

        public string? KeyWord
        {
            get => _keyWord;
            set => this.RaiseAndSetIfChanged(ref _keyWord, value);
        }

        public EvaluationListViewModel(IScreen screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            _items = new ObservableCollection<Medicine_Evaluation>(CreateItems());
            QueryBtn = ReactiveCommand.Create(() =>
            {
                _items = new ObservableCollection<Medicine_Evaluation>(CreateItems());
            });
        }

        private List<Medicine_Evaluation> CreateItems()
        {
            using (MyDbContext db = new MyDbContext())
            {
                var evaluations = db.Medicine_Evaluation.AsNoTracking();
                if (!string.IsNullOrEmpty(KeyWord))
                {
                    evaluations = evaluations.Where(t => !string.IsNullOrEmpty(t.EvaluationName) && t.EvaluationName.Contains(KeyWord));
                }
                return evaluations.ToList();
            }
        }

        public ReactiveCommand<Unit, Unit> QueryBtn { get; }

        public void RunTheThing(string parameter)
        {
            int.TryParse(parameter, out int resultId);
            using (MyDbContext db = new MyDbContext())
            {
                Medicine_Evaluation record = db.Medicine_Evaluation.Find(resultId);
                if (null != record)
                {
                    db.Medicine_Evaluation.Remove(record);
                    int flag = db.SaveChanges();
                    if (flag > 0)
                    {
                        HostScreen.Router.Navigate.Execute(new EvaluationListViewModel(HostScreen));
                    }
                }
            }
        }

    }
}
