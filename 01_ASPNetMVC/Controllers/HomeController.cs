﻿using _01_ASPNetMVC.Models;
using _01_ASPNetMVC.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace _01_ASPNetMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new IndexViewModel()
        {
            SpecialOffer = new SpecialOffer()
            {
                Image1 = "/Images/office-style.png",
                Image2 = "/Images/party-style.png",
                Offer = "50% Offer",
                Title = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Facilis, ipsam quo voluptatum facere iure fuga. Necessitatibus quasi voluptatem delectus nam?",

            },


            IntroOffer = new Intro()
            {
                Title1 = "Don't Miss This Opportunity",
                Title2 = "GET UP TO 40% OFF",
                Title3 = "Online shopping free home delivery over $100",

            },

            Showcase = new CollectionModel
            {

                Title = "Featured Products",
                CollectionItems = new List<CollectionItemModel>
                {
                    new CollectionItemModel { ID = "1", Category = "Coat", Title = "Very large and old coat", Price = 300m, ImageUrl = "/Images/coatt.png" },
                    new CollectionItemModel { ID = "2", Category = "Coat", Title = "Very large and old coat", Price = 300m, ImageUrl = "/Images/coatt.png" },
                    new CollectionItemModel { ID = "3", Category = "Coat", Title = "Very large and old coat", Price = 300m, ImageUrl = "/Images/coatt.png" },
                    new CollectionItemModel { ID = "4", Category = "Coat", Title = "Very large and old coat", Price = 300m, ImageUrl = "/Images/coatt.png"},
                    new CollectionItemModel { ID = "5", Category = "Coat", Title = "Very large and old coat", Price = 300m, ImageUrl = "/Images/coatt.png"},
                    new CollectionItemModel { ID = "6", Category = "Coat", Title = "Very large and old coat", Price = 300m, ImageUrl = "/Images/coatt.png" },
                    new CollectionItemModel { ID = "7", Category = "Coat", Title = "Very large and old coat", Price = 300m, ImageUrl = "/Images/coatt.png" },
                    new CollectionItemModel { ID = "8", Category = "Coat", Title = "Very large and old coat", Price = 300m, ImageUrl = "/Images/coatt.png" },
                    new CollectionItemModel { ID = "9", Category = "Coat", Title = "Very large and old coat", Price = 300m, ImageUrl = "/Images/coatt.png" },

                }

            },


         
    
        };





        //ViewData["Category"] = "Featured Products";
        return View(viewModel);
    }
}
