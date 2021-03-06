﻿using System.Collections.Generic;
using ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Services
{
    public interface IBookService
    {
        IList<Book> Get();

        IList<Book> GetByCategoryId(int categoryId);

        IList<Book> GetFeatured();

        Book GetById(int id);
    }
}

