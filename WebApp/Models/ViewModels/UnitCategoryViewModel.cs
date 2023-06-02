using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models.Entities;

namespace WebApp.Models.ViewModels;

public class UnitCategoryViewModel
{
    public List<UnitEntity>? Units { get; set; }
    public SelectList? Categories { get; set; }
    public string? UnitCategory { get; set; }
    public string? SearchString { get; set; }

}
