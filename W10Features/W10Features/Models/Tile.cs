using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W10Features.Models
{
    public class Tile
    {
        public string Time { get; set; } 
        public string Message { get; set; } 
        public string Message2 { get; set; }
        public string Branding { get; set; } 
        public string AppName { get; set; } 

        public Tile()
        {
            Time = "8:15 AM, Saturday";
            Message= "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore.";
            Message2 = " At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident.";
            Branding = "Company";
            AppName = "W10Features";
        }

        public Tile(string time, string msg, string msg2, string branding, string appName)
        {
            Time = time;
            Message = msg;
            Message2 = msg2;
            Branding = branding;
            AppName = appName;
        }
    }
}
