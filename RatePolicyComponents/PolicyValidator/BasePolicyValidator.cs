using RatePolicyComponents.PolicyValidator;
using RatePolicyData;
using System.Diagnostics;
using System.IO;

namespace RatePolicyComponents.PolicyRate
{
    public abstract class BasePolicyValidator : IPolicyValidator
    {
        public event EventHandler<PolicyValidationEventArgs> PolicyValidationState;

        public bool IsValid(Policy policy)
        {
            string errorMessage = string.Empty;

            if (PolicyValidationState != null)
                PolicyValidationState(this, new PolicyValidationEventArgs() { NotificationText = $"Validating {policy.Type} policy." });

            bool isValid = IsPolicyValid(policy, out errorMessage);
            string notification = "Validation Succeeded!";
            if (!isValid)
                notification = "Policy Validation failed with message " + errorMessage;
            
            if (PolicyValidationState != null)
                PolicyValidationState(this, new PolicyValidationEventArgs() { NotificationText = notification});
            return isValid;

        }

        public abstract bool IsPolicyValid(Policy policy, out string errorMessage);
    }
}
