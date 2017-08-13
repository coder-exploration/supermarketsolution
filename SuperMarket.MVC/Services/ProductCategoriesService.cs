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
    public class ProductCategoriesService
    {
        private string API_URL = "http://localhost:53712/api/";

        public bool Create(ProductCategory pc)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API_URL);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync("productcategories", pc).Result;
            return response.IsSuccessStatusCode;
        }
        public IEnumerable<ProductCategory> Retrieve()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API_URL);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("productcategories").Result;
            if(response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<IEnumerable<ProductCategory>>().Result; 
            return null;
        }
        public bool Update(ProductCategory pc)
        {
            return true;
        }
        public bool Delete(ProductCategory pc)
        {
            return true;
        }
    }
}