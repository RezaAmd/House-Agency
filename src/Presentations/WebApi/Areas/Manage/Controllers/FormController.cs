using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Manage.Models;

namespace WebApi.Areas.Manage.Controllers
{
    [ApiController]
    [Area("Manage")]
    [Route("[area]/[controller]/[action]")]
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
        [HttpGet]
        public async Task<ApiResult<object>> GetAll([FromQuery] string keyword, CancellationToken cancellationToken = new())
        {

            return NotFound();
        }

        [HttpPost]
        public async Task<ApiResult<object>> Create([FromBody] CreateFormMDAO model, CancellationToken cancellationToken = new())
        {
            return BadRequest();
        }
        #endregion

        #region Control
        [HttpGet]
        public async Task<ApiResult<object>> GetAllControls(string formId, CancellationToken cancellationToken = new())
        {

            return NotFound();
        }

        [HttpPost]
        public async Task<ApiResult<object>> CreateControl([FromBody] CreateControlMDAO model, CancellationToken cancellationToken = new())
        {

            return BadRequest();
        }
        #endregion
    }
}
