﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfImageDal : EfRepositoryBase<Image, AppDbContext>, IImageDal
    {
    }
}
