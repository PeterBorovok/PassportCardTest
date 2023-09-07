using RatePolicyData;

namespace RatePolicyComponents.PolicyValidator
{
    public interface IPolicyValidator
    {
        event EventHandler<PolicyValidationEventArgs> PolicyValidationState;
        bool IsValid(Policy policy);
    }

    public class PolicyValidationEventArgs : EventArgs
    {
        public string NotificationText { get; set; }
    }
}