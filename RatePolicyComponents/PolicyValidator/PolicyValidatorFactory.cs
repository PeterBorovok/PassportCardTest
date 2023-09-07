using RatePolicyComponents.PolicyRate;
using TestRating;

namespace RatePolicyComponents
{
    public class PolicyValidatorFactory
    {
        public static BasePolicyValidator Create(PolicyType type)
        { 
            switch (type) 
            {
                case PolicyType.Health:
                    return new PolicyValidatorHealth();
                case PolicyType.Life:
                    return new PolicyValidatorLife();
                case PolicyType.Travel:
                    return new PolicyValidatorTravel();
                default:
                    return null;
            }
        }
    }
}
