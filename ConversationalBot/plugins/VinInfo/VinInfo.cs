using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationalBot.plugins.VinInfo
{
    public class VinInfo
    {
        [SKFunction, Description("Execute a generic scan of a given model and VIN provided. Model is a string like Mercedes, BMW, etc. and VIN is a string like 123AAGH")]
        public async Task<string> RunScanVinModel(
            [Description("Vehicle Identifier Number")] string vin,
            [Description("Model of the vehicle")] string? model)
        {
            return $"Scan executed for vin: {vin}, model: {model}";
        }

        [SKFunction, Description("Execute a generic scan of a given model and VIN provided. VIN is a string like 123AAGH")]
        public async Task<string> RunScanVin(
            [Description("Vehicle Identifier Number")] string vin)
        {
            return $"Scan executed for vin: {vin}";
        }

        [SKFunction, Description("Execute a TGS3 scan of a given vehicle, model or VIN provided. VIN is a string like 123AAGH")]
        public async Task<string> RunTGS3(
            [Description("Vehicle Identifier Number")] string vin)
        {
            return $"TGS3 scan executed for vin: {vin}";
        }
    }
}
