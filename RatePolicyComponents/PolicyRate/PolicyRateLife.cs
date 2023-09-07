using RatePolicyData;

namespace RatePolicyComponents.PolicyRate
{
    public class PolicyRateLife : BasePolicyRate
    {
        public override decimal RatePolicy(Policy policy)
        {
            decimal rate;
            int age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = policy.Amount * age / 200;
            if (policy.IsSmoker)
                rate = baseRate * 2;
            else
                rate = baseRate;
            return rate;
        }
    }
}