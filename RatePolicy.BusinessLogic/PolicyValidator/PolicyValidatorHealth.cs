using RatePolicyData;
using System;
using System.Numerics;

namespace RatePolicyComponents.PolicyRate
{
    public class PolicyValidatorHealth : BasePolicyValidator
    {
        protected override bool IsPolicyValid(Policy policy, out string errorMessage)
        {
            if (String.IsNullOrEmpty(policy.Gender))
            {
                errorMessage = "Health policy must specify Gender";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}