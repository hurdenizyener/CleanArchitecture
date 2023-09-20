using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Common;

public abstract class BaseController : ControllerBase
{
    private IMediator? _mediator;

    //Daha önce mediator enjekte edilmişse onu döndür.Yoksa IOC Ortamına bak bana karşılığını ver.
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}

