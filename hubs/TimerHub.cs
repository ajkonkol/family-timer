using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace family_timer.Hubs
{
    public class TimerHub : Hub
    {

        //private static TimerHub _singleton;
        //private static System.Threading.Timer _timer;

        //private IHubContext<TimerHub> _hubContext;


        // public TimerHub(IHubContext<TimerHub> hubContext)
        // {
        //     _hubContext = hubContext;

        //     if (_timer == null) 
        //     {
        //         _timer = new System.Threading.Timer(
        //         new System.Threading.TimerCallback(TimerTask),
        //         null, 1000, 1000);
        //     }

        
        //    // _singleton = new TimerHub();

        // }
      

        // public void TimerTask(object timerState)
        // {
            
        //     var context =_hubContext;
        //     context.Clients.All.SendAsync("ReceiveMessage", "hello");

        // }

        
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}