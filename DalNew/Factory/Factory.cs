using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Factory
{
    public static class Factory
    {
        private static readonly UserMemoryContext userMemoryContext = new UserMemoryContext();

        public static IUserDal GetUserDal()
        {
            return userMemoryContext;
        }
    }
}
