using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestRating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatePolicyData;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using RatePolicyComponents.PolicyRate;
using RatePolicyComponents;

namespace TestRating.Tests
{
    [TestClass()]
    public class RatingEngineTests
    {
        
        [TestMethod()]
        public void RateTest()
        {
            string policyJson = File.ReadAllText("policy.json");//appSettingsObject.Settings["PolicyJsonLocation"]);
            var policy = JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());

            // Original solution gave final rating of 75 
            BasePolicyValidator policyValidator = PolicyValidatorFactory.Create(policy.Type);
            BasePolicyRate policyRate = PolicyRateFactory.Create(policy.Type);

            var engine = new RatingEngine(policyValidator, policyRate);
             engine.Rate(policy);

            decimal newRating = engine.Rating;
            Assert.AreEqual(newRating, 75);
        }
    }
}