using System.Web;
using System.Web.Mvc;

namespace HotelManagerWithNET_F
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
