using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _01_ASPNetMVC.Models;
using _01_ASPNetMVC.ViewModels;

public class ProductsController : Controller
{
    
    private readonly HttpClient _httpClient;

    public ProductsController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("myApi");
		
	}


    [HttpGet]
    public async Task<List<CollectionItemModel>> GetProductsByTag(string tag)
    {
        _httpClient.DefaultRequestHeaders.Add("x-api-key", "755d128a-d2ae-43f9-a521-41712709f1b5");
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


    public async Task<CollectionItemModel> GetProductById(int id)
    {
        _httpClient.DefaultRequestHeaders.Add("x-api-key", "755d128a-d2ae-43f9-a521-41712709f1b5");
        var response = await _httpClient.GetAsync($"/products/{id}");

        if (response.IsSuccessStatusCode)
        {
            var product = await response.Content.ReadAsAsync<CollectionItemModel>();
            return product;
        }
        else
        {
            throw new Exception("Failed to retrieve product from API");
        }
    }
    public async Task<IActionResult> QuickView(int id)
    {
        var product = await GetProductById(id);
        return View(product);
    }

	




}
