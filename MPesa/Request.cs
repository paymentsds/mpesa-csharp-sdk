using System;
using System.Globalization;

namespace MPesa
{
    public class Request
    {
        // Receive Money
        public double Amount { get; private set; }
        public string From { get; private set; }
        public string Reference { get; private set; }
        public string Transaction { get; private set; }

        // Send Money
        public string To { get; set; }

        // Query status
        public string Subject { get; set; }

        public Request(double amount, string from, string reference, string transaction, string to, string subject)
        {
            Amount = amount;
            From = from;
            Reference = reference;
            Transaction = transaction;
            To = to;
            Subject = subject;
        }

        public class Builder
        {
            // Receive Money
            private double AmountValue { get; set; }
            private string FromValue { get; set; }
            private string ReferenceValue { get; set; }
            private string TransactionValue { get; set; }

            // Send Money
            private string ToValue { get; set; }

            // Query status
            private string SubjectValue { get; set; }

            public Builder Amount(double amount)
            {
                AmountValue = amount;
                return this;
            }

            public Builder From(string from)
            {
                FromValue = from;
                return this;
            }

            public Builder Reference(string reference)
            {
                ReferenceValue = reference;
                return this;
            }

            public Builder Transaction(string transaction)
            {
                TransactionValue = transaction;
                return this;
            }

            public Builder To(string to)
            {
                ToValue = to;
                return this;
            }

            public Builder Subject(string subject)
            {
                SubjectValue = subject;
                return this;
            }

            public Request Build()
            {
                if (FromValue != null && ToValue != null)
                {
                    throw new ArgumentNullException(FromValue, "Request cannot contain both 'from' and 'to' arguments");
                }

                // This is required by all requests
                if (ReferenceValue == null)
                {
                    throw new ArgumentNullException(ReferenceValue, "Request must contain a reference");
                }

                // Handle C2B, B2C and B2B
                if (FromValue != null || ToValue != null)
                {
                    if (AmountValue == 0)
                    {
                        throw new ArgumentNullException(AmountValue.ToString(CultureInfo.InvariantCulture),
                            "Request must contain an amount greater than 0");
                    }

                    if (TransactionValue == null)
                    {
                        throw new ArgumentNullException(TransactionValue,
                            "Request must contain a transaction reference");
                    }
                }

                // Handle reversals
                if (ToValue == null && FromValue == null && SubjectValue == null)
                {
                    if (TransactionValue == null)
                    {
                        throw new ArgumentNullException(TransactionValue,
                            "Request must contain a transaction reference");
                    }
                }

                return new Request(AmountValue, FromValue, ReferenceValue, TransactionValue, ToValue, SubjectValue);
            }
        }
    }
}