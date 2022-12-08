using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandSharp.Commands
{
    public class ChangePromptCommand : Command
    {
        private static readonly CommandData data = new CommandData("prompt", "Changes to another prompt.", new string[] { "cdp", "cp", "pp", "tty" });

        public ChangePromptCommand() : base(data)
        {

        }

        public override bool OnInvoke(CommandInvokeParameters e)
        {
            var pr = PromptRegistry.INSTANCE;
            var args = e.Arguments;
            if (args.IsEmpty)
                return false;
            else
            {
                var x = args[0];
                if (pr.ContainsPrompt(x) || !char.IsNumber(x[0]))
                {
                    var p = CommandPrompt.GetPrompt(x);
                    p.Prompt(true);
                }
                else if (!pr.ContainsPrompt(x) || char.IsNumber(x[0]))
                {
                    var i = int.Parse(x[0].ToString());
                    var p = pr[i];
                    p.Prompt(true);
                }
                return true;
            }
        }
    }
}
