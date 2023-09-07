using RatePolicyData;
using System;
using System.Numerics;

namespace RatePolicyComponents.PolicyRate
{
    public class PolicyValidatorTravel : BasePolicyValidator
    {
        public override bool IsPolicyValid(Policy policy, out string errorMessage)
        {
            decimal rate;
            if (policy.Days <= 0)
            {
                errorMessage = "Travel policy must specify Days.";
                return false;
            }
            if (policy.Days > 180)
            {
                errorMessage = "Travel policy cannot be more then 180 Days.";
                return false;
            }
            if (String.IsNullOrEmpty(policy.Country))
            {
                errorMessage = "Travel policy must specify country.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }
    }
}