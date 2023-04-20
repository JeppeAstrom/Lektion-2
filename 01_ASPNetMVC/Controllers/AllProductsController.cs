using _01_ASPNetMVC.Models;
using _01_ASPNetMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class AllProductsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AllProductsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<List<CollectionItemModel>> GetProductsByTag(string tag)
    {
        using var httpClient = _httpClientFactory.CreateClient("myApi");
        httpClient.DefaultRequestHeaders.Add("x-api-key", "755d128a-d2ae-43f9-a521-41712709f1b5");
        var response = await httpClient.GetAsync($"/products/tag/{tag}");

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
        var featuredProductsTask = GetProductsByTag("Featured");
        var newProductsTask = GetProductsByTag("New");
        var popularProductsTask = GetProductsByTag("Popular");

      
        await Task.WhenAll(featuredProductsTask, newProductsTask, popularProductsTask);

        var viewModel = new AllProductsViewModel
        {
            Showcase = new CollectionModel { Title = "Featured", CollectionItems = await featuredProductsTask },
            NewProducts = new CollectionModel { Title = "New Products", CollectionItems = await newProductsTask },
            PopularProducts = new CollectionModel { Title = "Popular Products", CollectionItems = await popularProductsTask }
        };

        return View(viewModel);
    }
}
