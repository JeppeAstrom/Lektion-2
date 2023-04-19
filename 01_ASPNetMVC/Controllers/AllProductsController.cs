using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _01_ASPNetMVC.Models;
using _01_ASPNetMVC.ViewModels;

public class AllProductsController : Controller
{
    private readonly HttpClient _httpClient;

    public AllProductsController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("myApi");
	
	}

    [HttpGet]
    public async Task<List<CollectionItemModel>> GetProductsByTag(string tag)
    {
        var response = await _httpClient.GetAsync($"/products/tag/{tag}");

        if (response.IsSuccessStatusCode)
        {
            var products = await response.Content.ReadAsAsync<List<CollectionItemModel>>();
            return products;
        }
        else
        {
            throw new Exception("Failed to retrieve products from API");
        }
    }

	public async Task<IActionResult> Index()
	{
		var viewModel = new AllProductsViewModel
		{
			Showcase = new CollectionModel { Title = "Featured", CollectionItems = await GetProductsByTag("Featured") },
			NewProducts = new CollectionModel { Title = "New Products", CollectionItems = await GetProductsByTag("New") },
			PopularProducts = new CollectionModel { Title = "Popular Products", CollectionItems = await GetProductsByTag("Popular") }
		};

		return View(viewModel);
	}

}
