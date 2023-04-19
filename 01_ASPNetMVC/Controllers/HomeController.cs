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
		private readonly HttpClient _httpClient;

		public HomeController(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("myApi");
		}

		public async Task<CollectionModel> GetProductsByTag(string tag)
		{
			var response = await _httpClient.GetAsync($"/products/tag/{tag}");

			if (response.IsSuccessStatusCode)
			{
				var products = await response.Content.ReadAsAsync<List<CollectionItemModel>>();
				return new CollectionModel { CollectionItems = products };
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
