using Application.Extentions;
using Application.Models;
using Application.Models.Dto;
using Application.Models.ViewModels;
using Application.Services;
using AspNetCore.FileServices;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Areas.Manage.Controllers
{
    [ApiController]
    [Area("manage")]
    [Route("[area]/[controller]/[action]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PossessionController : ControllerBase
    {
        #region Dependency Injection
        private readonly IPossessionService possessionService;
        private readonly IAttachmentService attachmentService;

        public PossessionController(IPossessionService _possessionService,
            IAttachmentService _attachmentService)
        {
            possessionService = _possessionService;
            attachmentService = _attachmentService;
        }
        #endregion

        [HttpGet]
        public ApiResult<object> GetPossessionTypes()
        {
            var resultList = new List<SelectItem>();

            var maskooni = new SelectItem(PossessionApplicationType.Residential, true);
            maskooni.Children = new List<SelectItem>();
            maskooni.Children.Add(new SelectItem(PossessionType.Vila_Garden, true));
            maskooni.Children.Add(new SelectItem(PossessionType.Apartment_Tower));
            maskooni.Children.Add(new SelectItem(PossessionType.RealEstate));
            maskooni.Children.Add(new SelectItem(PossessionType.Land_OldHouse));
            maskooni.Children.Add(new SelectItem(PossessionType.Penthouse));
            resultList.Add(maskooni);

            var edari = new SelectItem(PossessionApplicationType.CommercialOffice);
            edari.Children = new List<SelectItem>();
            edari.Children.Add(new SelectItem(PossessionType.Vila_Garden, true));
            edari.Children.Add(new SelectItem(PossessionType.Warehouse_Factory_Workshop));
            edari.Children.Add(new SelectItem(PossessionType.Agriculture));
            edari.Children.Add(new SelectItem(PossessionType.RealEstate));
            edari.Children.Add(new SelectItem(PossessionType.Land_OldHouse));
            resultList.Add(edari);

            return Ok(resultList);
        }

        [HttpPost]
        [ModelStateValidator]
        public async Task<ApiResult<object>> Entrust([FromBody] PossessionDto model)
        {
            string? userId = User.GetCurrentUserId();
            if (string.IsNullOrEmpty(userId))
            {
                var newPossession = new Possession(model.Base.title, model.Base.meter, model.Base.RegionId,
                    model.Base.Type, model.Base.ApplicationType, model.Base.TransactionType,
                    "c46c9f0f-cabf-47c4-ba70-505085f386bd", DateTime.Now.AddYears(-5), model.Base.description);

                var createNewPossessionResult = await possessionService.CreateAsync(newPossession);
                if (createNewPossessionResult.Succeeded)
                {
                    return Ok(newPossession.Id);
                }
                else
                {
                    return BadRequest(createNewPossessionResult.Errors);
                }
            }
            return Ok(model);
        }

        [HttpPost]
        public async Task<ApiResult<object>> UploadAttachments([FromForm] List<IFormFile> images,
            CancellationToken cancellationToken = default)
        {
            var previewList = new List<PreviewFileVM>();
            string path = "assets/images/possessions/";
            foreach (var file in images)
            {
                string newName = DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss_fffffff");
                var newAttachment = new Attachment(newName, path, file.Length);
                var result = await attachmentService.CreateAsync(newAttachment, file, cancellationToken);
                previewList.Add(new PreviewFileVM(id: newAttachment.Id,
                    fullPath: "https://realestateapi.techonit.org/" + path + newName + Path.GetExtension(file.FileName),
                    isSuccess: result.Succeeded));
            }
            return Ok(previewList);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult<object>> DeleteAttachments([FromRoute] string id,
            CancellationToken cancellationToken = default)
        {
            var attachment = await attachmentService.FindByIdAsync(id, cancellationToken);
            if(attachment != null)
            {
                var deleteResult = await attachmentService.DeleteAsync(attachment, cancellationToken);
                if (deleteResult.Succeeded)
                {
                    return Ok("عکس مورد نظر با موفقیت حذف شد.");
                }
                return BadRequest(deleteResult.Errors);
            }
            return NotFound("عکس مورد نظر پیدا نشد.");
        }
    }
}