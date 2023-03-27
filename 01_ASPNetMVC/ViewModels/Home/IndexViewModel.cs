using _01_ASPNetMVC.Models;

namespace _01_ASPNetMVC.ViewModels.Home
{
    public class IndexViewModel
    {
        public CollectionModel Showcase { get; set; } = null!;

        public Intro IntroOffer { get; set; } = null!;  

        public SpecialOffer SpecialOffer { get; set; } = null!;



    }
}
