﻿using Microsoft.AspNetCore.Mvc.Testing;
using MyApp;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTests.Controllers
{
    public class ValuesControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;

        public ValuesControllerTest(WebApplicationFactory<Startup> webApplicationFactory)
        {
            _httpClient = webApplicationFactory.CreateClient();
        }

        public class Get : ValuesControllerTest
        {
            public Get(WebApplicationFactory<Startup> webApplicationFactory) : base(webApplicationFactory) { }

            [Fact]
            public async Task ShouldRespondAStatus200OKAsync()
            {
                // Act
                var result = await _httpClient.GetAsync("/api/values");

                // Assert
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            }

            [Fact]
            public async Task ShouldRespondTheExpectedStringsAsync()
            {
                // Act
                var result = await _httpClient.GetAsync("/api/values");

                // Assert
                var contentText = await result.Content.ReadAsStringAsync();
                var content = JsonSerializer.Deserialize<string[]>(contentText);
                Assert.Collection(content,
                    x => Assert.Equal("value1", x),
                    x => Assert.Equal("value2", x)
                );
            }
        }
    }
}
