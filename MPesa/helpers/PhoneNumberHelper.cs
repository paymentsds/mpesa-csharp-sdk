using System;

namespace MPesa.helpers
{
    public static class PhoneNumberHelper
    {
        public static string PhoneNumber(string phoneNumber, string requestType)
        {
            if (phoneNumber.StartsWith("258") && phoneNumber.Length == 12)
            {
                return phoneNumber;
            }
            
            if (phoneNumber.StartsWith("00258") && phoneNumber.Length == 14)
            {
                return phoneNumber.Remove(0, 2);
            }

            if (phoneNumber.StartsWith("+258") && phoneNumber.Length == 13)
            {
                return phoneNumber.Remove(0, 1);
            }

            if (phoneNumber.StartsWith("84") && phoneNumber.Length == 9)
            {
                return "258" + phoneNumber;
            }

            throw new ArgumentException($"Request field '{requestType}' : {phoneNumber} is invalid.",phoneNumber);
            
        }
    }
}