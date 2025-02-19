using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Moq;
using TelexApm.Extensions;
using TelexApm.Services;
using Xunit;

namespace TelexApm.Tests;

public class TelexMiddleWareTests
{
    private readonly Mock<ITelexClient> _mockTelexClient;
    private readonly RequestDelegate _nextMiddleware;
    private readonly TelexMiddleWare _middleware;
    private readonly DefaultHttpContext _httpContext;

    public TelexMiddleWareTests()
    {
        _mockTelexClient = new Mock<ITelexClient>();
        _nextMiddleware = (_) => Task.CompletedTask; //the underscore is an httpContext but since i'm returnning immediately, i used the discard symbol

        _middleware = new TelexMiddleWare(_nextMiddleware, _mockTelexClient.Object);
        _httpContext = new DefaultHttpContext();
    }

    [Fact]
    public async Task InvokeAsync_ShouldTrackTimeComplexity_OnRequestComplete()
    {
        await _middleware.InvokeAsync(_httpContext);
        _mockTelexClient.Verify(txClient => txClient.TrackPerformanceAsync(It.Is<string>(s => !string.IsNullOrEmpty(s)), It.Is<TimeSpan>(duration => true)), Times.Once);
    }

    [Fact]
    public async Task InvokeAsync_ShouldReportGlobalError_WhenUnhandledExceptionOccurs()
    {
        Exception exception = new("Mocking an unhandled error");
        var failingMiddleware = new TelexMiddleWare((cxt) => throw exception, _mockTelexClient.Object);
        await Assert.ThrowsAsync<Exception>(() => failingMiddleware.InvokeAsync(_httpContext));

        _mockTelexClient.Verify(txCleint => txCleint.TrackErrorAsync(exception), Times.Once);
    }
}