using MBwebapi.Data;
using MBwebapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace MBwebapi.Controllers
{
    public static class ProductApiurl
    {
        public const string Base = "api/product";
        public const string Product = "product";
        public const string ProductById = "product/{id}";
    }
    
    [ApiController]
    [Route(ProductApiurl.Base)]
    public class ProductsController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly masterContext _context;

        public ProductsController(HttpClient httpClient, masterContext context)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customer.ToListAsync();
        }

        [HttpPost]
        [Route("add-customer")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is required.");
            }

            try
            {
                int i = 0;
                await _context.Customer.AddAsync(customer);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCustomers), new { id = customer.CustId }, customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error saving customer: {ex.Message}");
            }
        }

        



        // GET: api/Customers



        [HttpGet]
        [Route(ProductApiurl.Product)]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _httpClient.GetAsync("https://dummyjson.com/products");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Failed to fetch products");

            var content = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<ProductResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return Ok(products);
        }
        [HttpGet]
        [Route(ProductApiurl.ProductById)]
        public async Task<IActionResult> GetProductById(int id)
        {
            var response = await _httpClient.GetAsync($"https://dummyjson.com/products/{id}");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, $"Failed to fetch product with ID {id}");

            var content = await response.Content.ReadAsStringAsync();
            var product = JsonSerializer.Deserialize<Product>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return Ok(product);
        }



        
       
            [HttpGet("check")]
            public IActionResult CheckPalindrome([FromQuery] string input)
            {
                if (string.IsNullOrWhiteSpace(input))
                    return BadRequest("Input cannot be empty.");

                bool isPalindrome = IsPalindrome(input);
                string bnewstring = StrRev(input);
                return Ok(new
                {
                    input = input,
                    isPalindrome = isPalindrome
                });
            }

            private bool IsPalindrome(string input)
            {
                string cleaned = input.ToLower(); // You can add .Replace(" ", "") to ignore spaces
                int len = cleaned.Length;

                for (int i = 0; i < len / 2; i++)
                {
                    if (cleaned[i] != cleaned[len - i - 1])
                        return false;
                }
                return true;
            }

            private string StrRev(string rever)
            {
                string newstring =string.Empty;
                
                int len = rever.Length;
                
                for(int i = len-1; i >= 0; i--)
                {
                  newstring +=rever[i];
                }
               return newstring;
            }
        

    }
}
