using FunctionApp1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace WatchFunctionTests
{
    public class WatchInfoUnitTests
    {
        [Fact]
        public async Task WatchInfo_GivenModel_ShouldBeOk()
        {
            // Arrange
            var req = new DefaultHttpRequest(new DefaultHttpContext())
            {
                Query = new QueryCollection(new Dictionary<string, StringValues>()
                {
                    { "model", "Orient Automatic 3" },
                }),
            };
            var log = NullLoggerFactory.Instance.CreateLogger("Null logger");

            // Act
            var response = await WatchInfo.Run(req, log);

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(response);
        }

        [Fact]
        public async Task WatchInfo_GivenNoQueryString_ShouldBadRequest()
        {
            var req = new DefaultHttpRequest(new DefaultHttpContext());
            var log = NullLoggerFactory.Instance.CreateLogger("Null logger");

            // Act
            var response = await WatchInfo.Run(req, log);

            // Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(response);
            Assert.Equal("Please provide a watch model in the query string",
                ((BadRequestObjectResult)response).Value);
        }
    }
}
