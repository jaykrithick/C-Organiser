using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FileOrganiser
{
    public class Organizer
    {

        private readonly Timer _timer;

        public Organizer()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object? sender, ElapsedEventArgs e)
        {
            
        }
    }
}
