using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RatePolicyComponents.PolicyRate;
using RatePolicyComponents.PolicyValidator;
using RatePolicyData;
using System;
using System.IO;

namespace TestRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public partial class RatingEngine
    {
        private readonly IPolicyValidator policyValidator;
        private readonly IPolicyRate policyRate;

        public RatingEngine(IPolicyValidator policyValidator, IPolicyRate policyRate)
        {
            this.policyValidator = policyValidator;
            this.policyRate = policyRate;
        }
        public decimal Rating { get; set; }
        public void Rate(Policy policy)
        {
            if (!policyValidator.IsValid(policy))
                throw new Exception("Invalid policy data");
            
            var rateVal = policyRate.Rate(policy);
            
            Rating = rateVal.HasValue ? rateVal.Value : throw new Exception("Unable to rate policy according to policy data");

            Console.WriteLine("Rating completed.");
        }
    }
}
