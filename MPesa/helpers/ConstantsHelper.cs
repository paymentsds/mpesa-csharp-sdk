namespace MPesa.helpers
{
    public  static class ConstantsHelper
    {
        public const int PORT_C2B = 18352;
        public const int PORT_B2B = 18349;
        public const int PORT_B2C = 18345;
        public const int PORT_QUERY = 18353;
        public const int PORT_REVERSAL = 18354;
        public const int PORT_CUSTOMER_NAME = 19323;

        public const string PATH_C2B = "c2bPayment/singleStage/";
        public const string PATH_B2B = "b2bPayment/";
        public const string PATH_B2C = "b2cPayment/";
        public const string PATH_QUERY = "queryTransactionStatus/";
        public const string PATH_REVERSAL = "reversal/";
        public const string PATH_CUSTOMER_NAME = "queryCustomerName/";
    }
}