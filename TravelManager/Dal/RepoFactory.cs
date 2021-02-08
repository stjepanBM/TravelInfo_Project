using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelManager.Dal
{
    public class RepoFactory
    {

        public static IRepository GetRepository()
        {
            return new SqlRepository();
        }




    }
}