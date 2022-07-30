using Application.Services.Forms;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.Manage.Controllers;

[ApiController]
[Area("Manage")]
[Route("[area]/[controller]/[action]")]
//[Authorize(Roles = "FormManage")]
public class FormController : ControllerBase
{
    #region Dependency Injection
    private readonly IFormService formService;

    public FormController(IFormService _formService)
    {
        formService = _formService;
    }
    #endregion

    #region Form
    //[HttpGet]
    //public async Task<ApiResult<object>> GetAll([FromQuery] string? keyword = null, [FromQuery] PaginationParameter? pagination = null, CancellationToken cancellationToken = new())
    //{

    //    return Ok(pagination);
    //}

    //[HttpPost]
    //public async Task<ApiResult<object>> Create([FromBody] CreateFormMDAO model, CancellationToken cancellationToken = new())
    //{
    //    return BadRequest();
    //}

    //[HttpDelete("{id}")]
    //public async Task<ApiResult<object>> Delete([FromRoute] string id, CancellationToken cancellationToken = new())
    //{

    //    return NotFound();
    //}

    //[HttpDelete]
    //public async Task<ApiResult<object>> CancelFormControl()
    //{

    //    return NotFound();
    //}
    #endregion

    #region Control
    //[HttpGet]
    //public async Task<ApiResult<object>> GetAllControls(string formId, [FromQuery] PaginationParameter? pagination = null, CancellationToken cancellationToken = new())
    //{
    //    // TODO: Get all controls / get all form controls.

    //    return NotFound();
    //}

    //[HttpPost]
    //public async Task<ApiResult<object>> CreateControl([FromBody] CreateControlMDAO model, CancellationToken cancellationToken = new())
    //{
    //    // TODO: create a new control.
    //    return BadRequest();
    //}

    //[HttpDelete("{id}")]
    //public async Task<ApiResult<object>> DeleteControl([FromRoute] string id, CancellationToken cancellationToken = new())
    //{

    //    return NotFound();
    //}
    #endregion
}
