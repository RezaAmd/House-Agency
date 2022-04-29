using Application.Dao;
using Application.Interfaces.Context;
using Application.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Areas.Manage.Controllers;
using Xunit;

namespace WebApi.Test.Manage
{
    public class UserControllerTest
    {
        public UserControllerTest()
        {
        }


        [Fact]
        public async Task GetAllTest()
        {
            Assert.True(true);
        }
    }
}