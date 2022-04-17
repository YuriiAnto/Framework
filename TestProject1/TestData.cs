using ApiTestFramework.Dto;
using System;
using System.Collections.Generic;

namespace ApiTestFramework
{
    public class TestData
    {
        public LocationResponse GetRandomPet()
        {
            Random rd = new Random();
            var randomNumber = rd.Next(10000, 90000);
            var jsonBody = new LocationResponse
            {
                Id = randomNumber,
                Category = new Category
                {
                    Id = 0,
                    Name = "string"
                },
                Name = "doggie",
                PhotoUrls = new List<string>
                {
                    "string"
                },
                Tags = new List<Tag>
                {
                    new Tag
                    {
                        Id = 0,
                        Name = "string"
                    }
                },
                Status = "available"
            };
            return jsonBody;
        }
    }
}
