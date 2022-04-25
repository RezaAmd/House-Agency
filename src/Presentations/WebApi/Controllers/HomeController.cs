using Application.Models;
using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
    }
}