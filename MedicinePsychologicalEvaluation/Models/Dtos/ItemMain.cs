using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinePsychologicalEvaluation.Models.Dtos
{
    public class ItemMain : ReactiveObject
    {
        public int id { get; set; }

        public int Rows { get; set; }

        public int EvaluationId { get; set; }

        public string? Title { get; set; }

        public string? Answer { get; set; }

        private string? background;

        public string? Background
        {
            get => background;
            set => this.RaiseAndSetIfChanged(ref background, value);
        }

        public List<ItemChild> ItemChilds { get; set; } = new List<ItemChild>();
    }

    public class ItemChild
    {
        public int parentId { get; set; }

        public string? SelectOption { get; set; }

        public int Score { get; set; }

        public bool IsCheck { get; set; }

    }

}
