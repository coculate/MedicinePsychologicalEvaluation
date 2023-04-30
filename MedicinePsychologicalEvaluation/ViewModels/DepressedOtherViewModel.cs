using MedicinePsychologicalEvaluation.Models;
using MedicinePsychologicalEvaluation.Models.Enums;
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
   public class DepressedOtherViewModel : ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }

        public string UrlPathSegment { get; } = "/depressedother";


        private ObservableCollection<Medicine_Evaluation> _items;

        public ObservableCollection<Medicine_Evaluation> Items
        {
            get => _items;
            set => this.RaiseAndSetIfChanged(ref _items, value);
        }

        public DepressedOtherViewModel(IScreen screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            _items = new ObservableCollection<Medicine_Evaluation>(CreateItems());
        }

        private List<Medicine_Evaluation> CreateItems()
        {
            using (MyDbContext db = new MyDbContext())
            {
                var evaluations = db.Medicine_Evaluation.Where(t => t.EvaluationType == EvaluationType.抑郁他评).AsNoTracking();
                return evaluations.ToList();
            }
        }

        public void RunTheThing(string parameter)
        {
            int.TryParse(parameter, out int evaluationId);
            HostScreen.Router.Navigate.Execute(new ProjectTestViewModel(HostScreen, evaluationId));
        }

    }
}
