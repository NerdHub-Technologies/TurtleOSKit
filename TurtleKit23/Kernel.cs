using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace TurtleKit23
{
    public class Kernel : Sys.Kernel
    {
        private CommandSharp.CommandPrompt Prompt;

        protected override void BeforeRun()
        {
            Prompt = new CommandSharp.CommandPrompt();
        }

        protected override void Run()
        {
            Prompt.Prompt(false);
        }
    }
}
