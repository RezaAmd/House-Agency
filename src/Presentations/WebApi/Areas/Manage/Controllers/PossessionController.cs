using Application.Extentions;
using Application.Models;
using Application.Models.Dto;
using Application.Services;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ApiResult<object>> GetPossessionTypes()
        {
            var resultList = new List<SelectItem>();

            var maskooni = new SelectItem("مسکونی", "1", true);
            maskooni.Children.Add(new SelectItem("ویلایی/باغ و باغچه", "1", true));
            maskooni.Children.Add(new SelectItem("آپارتمان/برج", "2"));
            maskooni.Children.Add(new SelectItem("مستغلات", "3"));
            maskooni.Children.Add(new SelectItem("زمین/کلنگی", "4"));
            maskooni.Children.Add(new SelectItem("پنت هاوس", "5"));
            resultList.Add(maskooni);

            var edari = new SelectItem("اداری/تجاری", "2");
            edari.Children.Add(new SelectItem("دفتر کار/اتاق اداری و مطب", "1", true));
            edari.Children.Add(new SelectItem("انبار/سوله/کارگاه و کارخانه", "2"));
            edari.Children.Add(new SelectItem("کشاورزی", "3"));
            edari.Children.Add(new SelectItem("مستغلات", "4"));
            edari.Children.Add(new SelectItem("زمین/کلنگی", "5"));
            resultList.Add(edari);


            return Ok(resultList);
        }

        [HttpGet]
        public async Task<ApiResult<object>> GetPossessionType(PossessionType type)
        {
            var selectTypeList = new List<SelectItem>();
            if (type == PossessionType.Residential)
            {
                selectTypeList.Add(new SelectItem()
                {
                    Text = "ویلایی/باغ و باغچه",
                    Value = "1",
                    IsDisabled = false,
                    IsSelected = true
                });
                selectTypeList.Add(new SelectItem()
                {
                    Text = "آپارتمان/برج",
                    Value = "2",
                    IsDisabled = false,
                    IsSelected = false
                });
                selectTypeList.Add(new SelectItem()
                {
                    Text = "مستغلات",
                    Value = "3",
                    IsDisabled = false,
                    IsSelected = false
                });
                selectTypeList.Add(new SelectItem()
                {
                    Text = "زمین/کلنگی",
                    Value = "4",
                    IsDisabled = false,
                    IsSelected = false
                });
                selectTypeList.Add(new SelectItem()
                {
                    Text = "پنت هاوس",
                    Value = "5",
                    IsDisabled = false,
                    IsSelected = false
                });
            }
            else if(type == PossessionType.CommercialOffice)
            {
                selectTypeList.Add(new SelectItem()
                {
                    Text = "دفتر کار/اتاق اداری و مطب",
                    Value = "1",
                    IsDisabled = false,
                    IsSelected = true
                });
                selectTypeList.Add(new SelectItem()
                {
                    Text = "انبار/سوله/کارگاه و کارخانه",
                    Value = "2",
                    IsDisabled = false,
                    IsSelected = false
                });
                selectTypeList.Add(new SelectItem()
                {
                    Text = "کشاورزی",
                    Value = "3",
                    IsDisabled = false,
                    IsSelected = false
                });
                selectTypeList.Add(new SelectItem()
                {
                    Text = "مستغلات",
                    Value = "4",
                    IsDisabled = false,
                    IsSelected = false
                });
                selectTypeList.Add(new SelectItem()
                {
                    Text = "زمین/کلنگی",
                    Value = "5",
                    IsDisabled = false,
                    IsSelected = false
                });
            }
            return Ok(selectTypeList);
        }

        [HttpPost]
        [ModelStateValidator]
        public async Task<ApiResult<object>> Entrust([FromBody] PossessionDto model)
        {
            string? userId = User.GetCurrentUserId();
            if (string.IsNullOrEmpty(userId))
            {
                var newPossession = new Possession(model.Base.title, model.Base.meter, model.Base.RegionId, model.Base.Type, model.Base.TransactionType,
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