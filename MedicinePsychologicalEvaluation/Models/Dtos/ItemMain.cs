using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinePsychologicalEvaluation.Models.Dtos
{
    public class ItemMain
    {
        public int id { get; set; }

        public int EvaluationId { get; set; }

        public string? Title { get; set; }

        public string? Answer { get; set; }

        public List<ItemChild> ItemChilds { get; set; } = new List<ItemChild>();
    }

    public class ItemChild
    {
        public int parentId { get; set; }

        public string? SelectOption { get; set; }

        public bool IsCheck { get; set; }

    }

}
