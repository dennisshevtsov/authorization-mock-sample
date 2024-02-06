// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Net;
using System.Net.Http.Headers;

namespace AuthorizationMockSample.Test;

[TestClass]
public class AuthorizationTest
{
  [TestMethod]
  public async Task GetAsync_NoBearerToken_401Returned()
  {
    // Arrange
    using HttpClient client = new();

    // Act
    using HttpResponseMessage response = await client.GetAsync("http://localhost:5001");

    // Assert
    Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
  }
}
