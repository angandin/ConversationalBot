using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.Planners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConversationalBot.Implementation
{
    internal class ConversationalManager
    {
        IKernel _kernel;
        static string pluginsDirectory = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "plugins");

        public ConversationalManager(IKernel kernel)
        {
            _kernel = kernel;
        }

        public async Task StartConversation()
        {
            //var queryPluginSemantic = _kernel.ImportSemanticFunctionsFromDirectory(pluginsDirectory, "");
            var queryPluginNative = _kernel.ImportFunctions(new ConversationalBot.plugins.VinInfo.VinInfo(), "VinInfo");

            string history = "[Assistant: What's your question?]";

            Console.WriteLine("What's your question?");
            var contextVariables = new ContextVariables
            {
                ["history"] = history
            };

            _kernel.CreateNewContext(contextVariables);

            while (true)
            {
                var input = Console.ReadLine();

                //contextVariables["history"] += $"[User: {input}]";

                var planner = new ActionPlanner(_kernel);
                var plan = await planner.CreatePlanAsync(input);

                var result = await _kernel.RunAsync(plan);

                Console.WriteLine("Plan results:");
                Console.WriteLine(result.GetValue<string>()!.Trim());

                history += $",[User: {input}],[Assistant: {result.GetValue<string>()}]";
                contextVariables.Set("history", history);
            }
        }
    }
}
