using TestRating;

namespace RatePolicyComponents.PolicyRate
{
    public class PolicyRateFactory
    {
        public static BasePolicyRate Create(PolicyType type)
        {
            switch (type)
            {
                case PolicyType.Health:
                    return new PolicyRateHealth();
                case PolicyType.Life:
                    return new PolicyRateLife();
                case PolicyType.Travel:
                    return new PolicyRateTravel();
                default:
                    return null;
            }
        }
    }
}
