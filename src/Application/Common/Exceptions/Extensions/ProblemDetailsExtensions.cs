using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Application.Common.Exceptions.Extensions;

public static class ProblemDetailsExtensions
{
    public static string AsJson<TPromlemDetail>(this TPromlemDetail details) where TPromlemDetail : ProblemDetails => JsonSerializer.Serialize(details);
}
