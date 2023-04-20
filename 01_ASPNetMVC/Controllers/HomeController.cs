using _01_ASPNetMVC.Models;
using _01_ASPNetMVC.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace _01_ASPNetMVC.Controllers
{
	public class HomeController : Controller
	{
    
            private readonly IHttpClientFactory _httpClientFactory;

            public HomeController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            // ...
        


        public async Task<CollectionModel> GetProductsByTag(string tag)
        {
            var httpClient = _httpClientFactory.CreateClient("myApi");
            httpClient.DefaultRequestHeaders.Add("x-api-key", "755d128a-d2ae-43f9-a521-41712709f1b5");

            var response = await httpClient.GetAsync($"/products/tag/{tag}");

            if (response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadAsAsync<List<CollectionItemModel>>();
                return new CollectionModel { Title = tag, CollectionItems = products };
            }

            else
            {
                throw new Exception("Failed to retrieve products from API");
            }
        }

        public async Task<IActionResult> Index()
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
				Showcase = await GetProductsByTag("Featured"),
				NewProducts = await GetProductsByTag("New"),
				PopularProducts = await GetProductsByTag("Popular")
			};
			return View(viewModel);
		}
	}
}
