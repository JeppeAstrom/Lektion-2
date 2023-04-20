using _01_ASPNetMVC.Models;
using _01_ASPNetMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

[Route("contacts")]
public class ContactsController : Controller
{
    private readonly HttpClient _httpClient;

    public ContactsController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("myApi");
		
	}


    public IActionResult Contacts()
    {
        var model = new ContactsFormModel();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddContact(ContactsFormModel model)
    {
        _httpClient.DefaultRequestHeaders.Add("x-api-key", "755d128a-d2ae-43f9-a521-41712709f1b5");
        if (ModelState.IsValid)
        {
            try
            {
                var contactsEntity = new ContactsEntity
                {
                    Name = model.Name,
                    Email = model.Email,
                    Comment = model.Message
                };

                await _httpClient.PostAsJsonAsync("api/contacts", contactsEntity);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error adding contact: {ex.Message}");
                return RedirectToAction("Index", "Home");
            }
        }

        return View(model);
    }
}
