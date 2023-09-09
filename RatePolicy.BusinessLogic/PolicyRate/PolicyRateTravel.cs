using RatePolicyData;

namespace RatePolicyComponents.PolicyRate
{
    public class PolicyRateTravel : BasePolicyRate
    {
        protected override decimal RatePolicy(Policy policy)
        {
            decimal rate;
            rate = policy.Days * 2.5m;
            if (policy.Country == "Italy")
            {
                rate *= 3;
            }

            return rate;
        }
    }
}