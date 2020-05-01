using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace FacultyV3.Web.Common
{
    [HubName("HitCounter")]
    public class HitCounter : Hub
    {
        private static int counter = 0;

        public override System.Threading.Tasks.Task OnConnected()
        {
            counter = counter + 1;
            var context = GlobalHost.ConnectionManager.GetHubContext<HitCounter>();
            context.Clients.All.UpdateCount(counter);
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnReconnected()
        {
            if (counter > 0)
                counter = counter - 1;
            var context = GlobalHost.ConnectionManager.GetHubContext<HitCounter>();
            context.Clients.All.UpdateCount(counter);
            return base.OnReconnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            counter = counter - 1;
            var context = GlobalHost.ConnectionManager.GetHubContext<HitCounter>();
            context.Clients.All.UpdateCount(counter);
            return base.OnDisconnected(stopCalled);
        }
    }
}