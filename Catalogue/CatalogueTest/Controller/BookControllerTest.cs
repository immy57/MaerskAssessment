
using Catalogue.API;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogueTest.Controller
{
    public class BookControllerTest
    {
        CustomWebApplicationFactory<Catalogue.API.Startup> _customWebApplicationFactory;
        public BookControllerTest()
        {
            _customWebApplicationFactory = new CustomWebApplicationFactory<Startup>();

        }

        public HttpClient GetClient() => _customWebApplicationFactory.CreateClient();

        [Test]
        public async Task BookControllerGetAll()
        {
            var client = GetClient();
            var result = await client.GetAsync("/api/Book/GetAllBooks");
            var responseString = await result.Content.ReadAsStringAsync();
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(responseString != null);
        }
    }
}
