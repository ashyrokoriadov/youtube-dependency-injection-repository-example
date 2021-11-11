using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPattern.Constants;
using System;
using System.Linq;

namespace RepositoryDesignPattern.Controllers
{
    public static class ControllerExtensions
    {
        public static Guid GetCorrelationId(this ControllerBase controller)
        {
            var correlationId = controller.HttpContext.Request
              .Headers
              .SingleOrDefault(header => header.Key == HeaderKeys.CORRELATION_ID)
              .Value;

            return string.IsNullOrEmpty(correlationId) ? Guid.Empty : Guid.Parse(correlationId);
        }
    }
}
