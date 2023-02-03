using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CommandSharp
{
    internal class PromptRegistry
    {
        public static PromptRegistry INSTANCE = new PromptRegistry();

        private List<CommandPrompt> prompts;

        public PromptRegistry()
        {
            prompts = new List<CommandPrompt>();
        }

        public CommandPrompt this[int i]
        {
            get => Count > 0 ? prompts[i] : null;
            internal set
            {
                if (value == null)
                    return;
                prompts[i] = value;
            }
        }

        public CommandPrompt this[string name]
        {
            get => GetPrompt(name);
            internal set
            {
                if (ContainsPrompt(name))
                {
                    var p = GetPrompt(name);
                    var i = prompts.IndexOf(p);
                    this[i] = value;
                }
                else
                    //Create new.
                    new CommandPrompt(name);
            }
        }

        public CommandPrompt GetPrompt(string name)
        {
            foreach (var x in prompts)
            {
                if (x.GetPromptName().Equals(name, StringComparison.OrdinalIgnoreCase))
                    return x;
                else continue;
            }
            return null;
        }

        public bool ContainsPrompt(string name)
            => GetPrompt(name) != null;

        public bool Contains(CommandPrompt p) => prompts.Contains(p);

        public void AddPrompt(CommandPrompt p)
        {
            if (!(ContainsPrompt(p.GetPromptName())))
                prompts.Add(p);
        }

        public void RemovePrompt(string prompt)
        {
            if (ContainsPrompt(prompt))
            {
                var p = GetPrompt(prompt);
                prompts.Remove(p);
            }
        }

        public int Count => prompts.Count;
    }
}
