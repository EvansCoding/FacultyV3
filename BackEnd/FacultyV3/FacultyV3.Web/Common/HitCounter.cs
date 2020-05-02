using FacultyV3.Core.Data.Context;
using FacultyV3.Core.Interfaces;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Linq;

namespace FacultyV3.Web.Common
{
    [HubName("HitCounter")]
    public class HitCounter : Hub
    {
        private static int counter = 0;

        public override System.Threading.Tasks.Task OnConnected()
        {
            string totalAccess = "";
            try
            {
                IDataContext dataContext = new DataContext();
                var total = dataContext.Confirgurations.Where(x => x.Meta_Name == Core.Constants.Constant.TOTAL_ACCESS && x.Meta_Value != null).SingleOrDefault();
                total.Meta_Value = (long.Parse(total.Meta_Value) + 1).ToString();
                dataContext.SaveChanges();
                totalAccess = total.Meta_Value;
            }
            catch (System.Exception)
            {
            }

            counter = counter + 1;
            var context = GlobalHost.ConnectionManager.GetHubContext<HitCounter>();
            context.Clients.All.UpdateCount(counter, totalAccess);
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            if(counter > 0)
                counter = counter - 1;
            var context = GlobalHost.ConnectionManager.GetHubContext<HitCounter>();
            context.Clients.All.UpdateCount(counter);
            return base.OnDisconnected(stopCalled);
        }
    }
}