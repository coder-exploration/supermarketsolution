using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using SuperMarket.MVC.Models;

namespace SuperMarket.MVC.Services
{
    public class ProductsService
    {
        private string API_URL = "http://localhost:53712/api/";

        public bool Create(Product p)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API_URL);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync("products", p).Result;
            return response.IsSuccessStatusCode;
        }
        public IEnumerable<Product> Retrieve(int categoryId = -1)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API_URL);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = (categoryId == -1 ? client.GetAsync("products").Result : client.GetAsync("products?categoryId=" + categoryId.ToString()).Result); 
            
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            return null;
        }
        public Product RetrieveById(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API_URL);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("products/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<Product>().Result;
            return null;
        }
        public bool Update(int id, Product p)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API_URL);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PutAsJsonAsync("products/" + id.ToString(), p).Result;
            return response.IsSuccessStatusCode;
        }
        public bool Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API_URL);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync("products/" + id.ToString()).Result;
            return response.IsSuccessStatusCode;
        }
    }
}