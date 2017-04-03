using NodeManagement;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace NodeManagerUI
{
    public class ValidationRuleBytesReceived : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            NetworkInterfaceObject node = (value as BindingExpression).DataItem as NetworkInterfaceObject;

            if (node != null && MaximumThresholdValues.MaxBytesReceived != 0 )
            {
                if (node.BytesReceived > MaximumThresholdValues.MaxBytesReceived)
                {
                    return new ValidationResult(false, "Exceeded Maximum Threshold Value");
                }
            }

            return ValidationResult.ValidResult;
        }
    }

    public class ValidationRuleBytesSent : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            NetworkInterfaceObject node = (value as BindingExpression).DataItem as NetworkInterfaceObject;

            if (node != null && MaximumThresholdValues.MaxBytesSent != 0)
            {
                if (node.BytesSent > MaximumThresholdValues.MaxBytesSent)
                {
                    return new ValidationResult(false, "Exceeded Maximum Threshold Value");
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}
