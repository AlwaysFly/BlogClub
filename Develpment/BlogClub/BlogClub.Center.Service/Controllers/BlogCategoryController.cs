using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogClub.Center.Contract;
using BlogClub.Center.Message.Request;
using BlogClub.Infrastructure.Message;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogClub.Center.Service.Controllers
{
    [Route("api/[controller]")]
    public class BlogCategoryController : Controller, IBlogCategoryService
    {
        [HttpGet]
        public ResponseMessage AddBlogCategory(AddBlogCategoryRequest reqMsg)
        {
            return new ResponseMessage { };
        }
    }
}
