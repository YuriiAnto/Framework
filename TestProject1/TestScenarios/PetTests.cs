using ApiTestFramework;
using ApiTestFramework.Base;
using ApiTestFramework.Dto;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GetTests
{
    public class Tests
    {
        [Test]
        public async Task PostNewPet()
        {
            var jsonBody = new TestData().GetRandomPet();
            var restLibrary = new RestLibrary();
            var url = new UrlBuilder()
                .WithVersion("/v2")
                .WithPet("/pet")
                .Build()
                .GetUrlString();
            //Create new Pet
            var response = await restLibrary.PostMethod(new RestRequest(url).AddJsonBody(jsonBody));
            var content = restLibrary.ReturnMethod<LocationResponse>(response);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(jsonBody.Id, content.Id);
            Assert.AreEqual(0, content.Category.Id);
            Assert.AreEqual("string", content.Category.Name);
            Assert.AreEqual("doggie", content.Name);
            Assert.AreEqual("string", content.PhotoUrls[0]);
            Assert.AreEqual(0, content.Tags[0].Id);
            Assert.AreEqual("string", content.Tags[0].Name);
            Assert.AreEqual("available", content.Status);
        }

        [Test]
        public async Task UpdatePetByPut()
        {
            var jsonBody = new TestData().GetRandomPet();
            var restLibrary = new RestLibrary();
            var url = new UrlBuilder()
                .WithVersion("/v2")
                .WithPet("/pet")
                .Build()
                .GetUrlString();
            //Create new Pet
            var responseOfCreatedPet = await restLibrary.PostMethod(new RestRequest(url).AddJsonBody(jsonBody));
            //Change Pet name
            jsonBody.Name = "PetPet";
            //Update created Pet
            var responseOfUpdatedPet = await restLibrary.PutMethod(new RestRequest(url).AddJsonBody(jsonBody));
            var content = restLibrary.ReturnMethod<LocationResponse>(responseOfUpdatedPet);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, responseOfUpdatedPet.StatusCode);
            Assert.AreEqual(jsonBody.Id, content.Id);
            Assert.AreEqual(0, content.Category.Id);
            Assert.AreEqual("string", content.Category.Name);
            Assert.AreEqual("PetPet", content.Name);
            Assert.AreEqual("string", content.PhotoUrls[0]);
            Assert.AreEqual(0, content.Tags[0].Id);
            Assert.AreEqual("string", content.Tags[0].Name);
            Assert.AreEqual("available", content.Status);
        }

        [Test]
        public async Task GetPetByStatus()
        {
            var restLibrary = new RestLibrary();
            var url = new UrlBuilder()
                .WithVersion("/v2")
                .WithPet("/pet")
                .WithFindByStatus("/findByStatus")
                .Build()
                .GetUrlString();
            var response = await restLibrary.GetMethod(new RestRequest(url).AddQueryParameter("status", "available"));
            var content = restLibrary.ReturnMethod<List<LocationResponse>>(response);
            var specificPet = content.SingleOrDefault(x => x.Id == 9223372000001095000);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(0, specificPet.Category.Id);
            Assert.AreEqual("string", specificPet.Category.Name);
            Assert.AreEqual("doggie", specificPet.Name);
            Assert.AreEqual("string", specificPet.PhotoUrls[0]);
            Assert.AreEqual(0, specificPet.Tags[0].Id);
            Assert.AreEqual("string", specificPet.Tags[0].Name);
            Assert.AreEqual("available", specificPet.Status);
        }

        [Test]
        public async Task GetPetById()
        {
            var restLibrary = new RestLibrary();
            //restLibrary.BaseUrl();
            //var request = new RestRequest("/v2/pet/findByStatus?status=available");
            var url = new UrlBuilder()
                .WithVersion("/v2")
                .WithPet("/pet")
                .WithPetId("/9876")
                .Build()
                .GetUrlString();
            //var request = new RestRequest(url);
            //var response = await restLibrary.Client.GetAsync(new RestRequest(url));
            var response = await restLibrary.GetMethod(new RestRequest(url));
            //var resres = JsonConvert.DeserializeObject<LocationResponse>(response1.Content);
            var content = restLibrary.ReturnMethod<LocationResponse>(response);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(9876, content.Id);
            Assert.AreEqual(0, content.Category.Id);
            Assert.AreEqual("string_name", content.Category.Name);
            Assert.AreEqual("doggie_name", content.Name);
            Assert.AreEqual("string", content.PhotoUrls[0]);
            Assert.AreEqual(9000, content.Tags[0].Id);
            Assert.AreEqual("string_tag", content.Tags[0].Name);
            Assert.AreEqual("available", content.Status);
        }

        [Test]
        public async Task DeletePet()
        {
            var jsonBody = new TestData().GetRandomPet();
            var restLibrary = new RestLibrary();
            var urlForPost = new UrlBuilder()
                .WithVersion("/v2")
                .WithPet("/pet")
                .Build()
                .GetUrlString();
            //Create new Pet
            var responseOfCreatedPet = await restLibrary.PostMethod(new RestRequest(urlForPost).AddJsonBody(jsonBody));
            Assert.AreEqual(HttpStatusCode.OK, responseOfCreatedPet.StatusCode);
            //Delete created Pet
            var urlForDelete = new UrlBuilder()
                .WithVersion("/v2")
                .WithPet("/pet")
                .WithPetId($"/{jsonBody.Id}")
                .Build()
                .GetUrlString();
            var responseOfDeletedPet = await restLibrary.DeleteMethod(new RestRequest(urlForDelete));
            var content = restLibrary.ReturnMethod<DeletedPet>(responseOfDeletedPet);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, responseOfDeletedPet.StatusCode);
            Assert.AreEqual(200, content.Code);
            Assert.AreEqual("unknown", content.Type);
            Assert.AreEqual(jsonBody.Id.ToString(), content.Message);
        }
    }
}
