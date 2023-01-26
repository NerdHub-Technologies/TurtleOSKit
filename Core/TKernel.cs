using Cosmos.System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleOSKit.Core
{
    public abstract class TKernel : Kernel
    {
        public static long Ticks { get; private set; }
        public static string CurrentDirectory { get; set; } = "0:\\";

        private DateTime timeStarted;
        private DateTime timeInit;
        private bool requiresInit;
        private bool firstRun;

        public event EventHandler Starting;
        public event EventHandler Started;
        public event EventHandler Shutdown;
        public event EventHandler Update;

        public TKernel()
        {
            Starting += (s, e) => 
            {
                timeInit = DateTime.Now;
                timeStarted = DateTime.Now;

                Ticks = 0;
            };
            Update += (s, e) => 
            {
                var now = DateTime.Now;
                Ticks = now.Subtract(timeStarted).Ticks;
            };
        }

        private new void BeforeRun()
        {
            FireStartingEvent(new EventArgs());
        }

        private new void AfterRun()
            => FireShutdownEvent(new EventArgs());

        private new void Run()
        {
            if (firstRun)
                FireStartedEvent(new EventArgs());
            FireUpdateEvent(new EventArgs());
        }

        public void FireEvent(string eventName, EventArgs e)
        {
            switch (eventName)
            {
                case (nameof(Starting)):
                    {
                        if (Starting != null)
                            Starting(this, e);
                        break;
                    }
                case (nameof(Started)):
                    {
                        if (Started != null)
                            Started(this, e);
                        break;
                    }
                case (nameof(Shutdown)):
                    {
                        if (Shutdown != null)
                            Shutdown(this, e);
                        break;
                    }
                case (nameof(Update)):
                    {
                        if (Update != null)
                            Update(this, e);
                        break;
                    }
            }
        }

        protected void FireStartingEvent(EventArgs e)
            => FireEvent(nameof(Starting), new EventArgs());
        protected void FireStartedEvent(EventArgs e)
            => FireEvent(nameof(Started), new EventArgs());
        protected void FireShutdownEvent(EventArgs e)
            => FireEvent(nameof(Shutdown), new EventArgs());
        protected void FireUpdateEvent(EventArgs e)
            => FireEvent(nameof(Update), new EventArgs());
    }
}
