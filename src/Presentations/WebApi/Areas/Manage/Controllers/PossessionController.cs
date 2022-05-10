using Application.Extentions;
using Application.Models;
using Application.Models.Dto;
using Application.Services;
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

        public PossessionController(IPossessionService _possessionService)
        {
            possessionService = _possessionService;
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

        //[HttpGet]
        //public async Task<ApiResult<object>> GetPossessionType(PossessionType type)
        //{
        //    var selectTypeList = new List<SelectItem>();
        //    if (type == PossessionType.Residential)
        //    {
        //        selectTypeList.Add(new SelectItem()
        //        {
        //            Text = "ویلایی/باغ و باغچه",
        //            Value = "1",
        //            IsDisabled = false,
        //            IsSelected = true
        //        });
        //        selectTypeList.Add(new SelectItem()
        //        {
        //            Text = "آپارتمان/برج",
        //            Value = "2",
        //            IsDisabled = false,
        //            IsSelected = false
        //        });
        //        selectTypeList.Add(new SelectItem()
        //        {
        //            Text = "مستغلات",
        //            Value = "3",
        //            IsDisabled = false,
        //            IsSelected = false
        //        });
        //        selectTypeList.Add(new SelectItem()
        //        {
        //            Text = "زمین/کلنگی",
        //            Value = "4",
        //            IsDisabled = false,
        //            IsSelected = false
        //        });
        //        selectTypeList.Add(new SelectItem()
        //        {
        //            Text = "پنت هاوس",
        //            Value = "5",
        //            IsDisabled = false,
        //            IsSelected = false
        //        });
        //    }
        //    else if(type == PossessionType.CommercialOffice)
        //    {
        //        selectTypeList.Add(new SelectItem()
        //        {
        //            Text = "دفتر کار/اتاق اداری و مطب",
        //            Value = "1",
        //            IsDisabled = false,
        //            IsSelected = true
        //        });
        //        selectTypeList.Add(new SelectItem()
        //        {
        //            Text = "انبار/سوله/کارگاه و کارخانه",
        //            Value = "2",
        //            IsDisabled = false,
        //            IsSelected = false
        //        });
        //        selectTypeList.Add(new SelectItem()
        //        {
        //            Text = "کشاورزی",
        //            Value = "3",
        //            IsDisabled = false,
        //            IsSelected = false
        //        });
        //        selectTypeList.Add(new SelectItem()
        //        {
        //            Text = "مستغلات",
        //            Value = "4",
        //            IsDisabled = false,
        //            IsSelected = false
        //        });
        //        selectTypeList.Add(new SelectItem()
        //        {
        //            Text = "زمین/کلنگی",
        //            Value = "5",
        //            IsDisabled = false,
        //            IsSelected = false
        //        });
        //    }
        //    return Ok(selectTypeList);
        //}

        [HttpPost]
        [ModelStateValidator]
        public async Task<ApiResult<object>> Entrust([FromBody] PossessionDto model)
        {
            string? userId = User.GetCurrentUserId();
            if (string.IsNullOrEmpty(userId))
            {
                var newPossession = new Possession(model.Base.title, model.Base.meter, model.Base.RegionId,
                    model.Base.Type, model.Base.ApplicationType, model.Base.TransactionType,
                    "c46c9f0f-cabf-47c4-ba70-505085f386bd", DateTime.Now.AddYears(-5));

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
    }
}