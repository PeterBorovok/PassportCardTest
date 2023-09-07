using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RatePolicyComponents;
using RatePolicyComponents.PolicyRate;
using RatePolicyData;
using System;
using System.IO;
using Utilities;

namespace TestRating
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insurance Rating System Starting...");
            //string appSettings = File.ReadAllText("App.config");
            //JsonSerializer jsonSerializer = new JsonSerializer();
            //var appSettingsObject = JsonConvert.DeserializeObject<AppSettingsObj>(appSettings);

            // load policy - open file policy.json
            string policyJson = File.ReadAllText("policy.json");//appSettingsObject.Settings["PolicyJsonLocation"]);
            var policy = Utilities.Utilities.GetPolicyObject(policyJson);

            BasePolicyValidator policyValidator = PolicyValidatorFactory.Create(policy.Type);
            BasePolicyRate policyRate = PolicyRateFactory.Create(policy.Type);

            var engine = new RatingEngine(policyValidator, policyRate);
            engine.Rate(policy);

            decimal rating = engine.Rating;
            if (rating > 0)
            {
                Console.WriteLine($"Rating: {rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }
        }
    }
}
