using ConversationalBot.Implementation;
using Microsoft.SemanticKernel;

namespace csharp_semantic_kernel
{
    public class Program
    {
        static KernelSettings? _kernelSettings;

        static async Task Main(string[] args)
        {
            _kernelSettings = KernelSettings.LoadSettings();
            IKernel kernel = new KernelBuilder()
                .WithCompletionService(_kernelSettings)
                //.WithLogger(logger)
                .Build();

            var conversationalManager = new ConversationalManager(kernel);
            await conversationalManager.StartConversation();
        }
    }
}