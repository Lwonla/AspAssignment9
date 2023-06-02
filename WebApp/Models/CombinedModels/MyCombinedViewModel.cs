//namespace WebApp.Models.CombinedModels

using WebApp.Models.Entities;

namespace WebApp.Models.ViewModels
{
    public class MyCombinedViewModel
    {
        public UnitEntity? Unit { get; set; }
        public UnitCategoryViewModel? Category { get; set; }
    }
}

