using Application.Common.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Common.Exceptions.HttpProblemDetails;

public sealed class ValidationProblemDetails : ProblemDetails
{
    public IEnumerable<ValidationExceptionModel> Errors { get; init; }

    public ValidationProblemDetails(IEnumerable<ValidationExceptionModel> errors)
    {
        Title = "Validation erros(s)";
        Detail = "detail";
        Status = StatusCodes.Status400BadRequest;
        Type = "https://example.com/probs/business";
        Errors = errors;
    }

}
