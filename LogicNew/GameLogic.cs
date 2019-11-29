using Dal;
using Dal.Factory;
using Dal.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class GameLogic
    {
        IUserDal Context;
        public GameLogic(bool sql)
        {
            if (sql)
            {
                Context = new UserSQLContext(); //UNFINISHED
            }
            else
            {
                Context = Factory.GetUserDal();
            }
        }
    }
}
