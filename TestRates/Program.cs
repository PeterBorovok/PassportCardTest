using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RatePolicyComponents;
using RatePolicyComponents.PolicyRate;
using RatePolicyComponents.PolicyValidator;
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
            if (policyValidator == null)
                throw new Exception("Validator Factory returned null");
            BasePolicyRate policyRate = PolicyRateFactory.Create(policy.Type);
            if (policyRate == null)
                throw new Exception("Rate Factory returned null");

            policyRate.PolicyRateState += PolicyRate_PolicyRateState;
            policyValidator.PolicyValidationState += PolicyValidator_PolicyValidationState;

        var engine = new RatingEngine(policyValidator, policyRate);

            engine.EngineStateNotified += Engine_EngineStateNotified;
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

        private static void Engine_EngineStateNotified(object sender, EngineStateEventArgs e)
        {
            Console.WriteLine($"Rate Engine notified state: {e.NotificationText}");
        }

        private static void PolicyValidator_PolicyValidationState(object? sender, PolicyValidationEventArgs e)
        {
            Console.WriteLine($"Policy Validator notified state: {e.NotificationText}");
        }

        private static void PolicyRate_PolicyRateState(object? sender, PolicyRateEventArgs e)
        {
            Console.WriteLine($"Policy Rate notified state: {e.NotificationText}");
        }
    }
}
