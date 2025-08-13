using System.Collections.Generic;

namespace BethanysPieShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Models.Pie> PiesOfTheWeek { get; set; }
        //public string? CurrentCategory { get; set; }
        public HomeViewModel(IEnumerable<Models.Pie> piesOfTheWeek)
        {
            PiesOfTheWeek = piesOfTheWeek;
            //CurrentCategory = currentCategory;
        }
    }
}
