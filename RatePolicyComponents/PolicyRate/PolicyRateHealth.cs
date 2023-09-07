using RatePolicyData;

namespace RatePolicyComponents.PolicyRate
{
    public class PolicyRateHealth : BasePolicyRate
    {
        public override decimal RatePolicy(Policy policy)
        {
            decimal rate;

            if (policy.Gender == "Male")
            {
                if (policy.Deductible < 500)
                {
                    rate = 1000m;
                }
                rate = 900m;
            }
            else
            {
                if (policy.Deductible < 800)
                {
                    rate = 1100m;
                }
                rate = 1000m;
            }

            return rate;
        }
    }
}