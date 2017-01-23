using BlogClub.Center.Message.Request;
using BlogClub.Infrastructure.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogClub.Center.Contract
{
    public interface IBlogCategoryService
    {
        ResponseMessage AddBlogCategory(AddBlogCategoryRequest reqMsg);
    }
}
