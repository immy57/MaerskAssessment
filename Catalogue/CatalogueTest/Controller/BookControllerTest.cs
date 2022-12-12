
using Catalogue.API;
using Catalogue.App.CommandHandler.CommandRequest;
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
        public async Task BookController_GetAll()
        {
            var client = GetClient();
            var result = await client.GetAsync("/api/Book/GetAllBooks");
            var responseString = await result.Content.ReadAsStringAsync();
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(responseString != null);
        }

        [Test]
        public async Task BookController_AddBook()
        {
            var client = GetClient();

            var response = await client.PostAsync("/api/Book/AddBook",
                   ContentHelper.GetStringContent(new AddBookCommand() { BookTitle = "2 State", BookAuthor = "Chetan bhagat", BookPrice = 12.12M }));
            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            Assert.IsTrue(value == "true");
        }
    }
}
