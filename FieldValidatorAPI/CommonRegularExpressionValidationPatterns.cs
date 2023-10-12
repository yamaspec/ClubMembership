namespace FieldValidatorAPI
{
    public static class CommonRegularExpressionValidationPatterns
    {
        public const string Email_Address_RegEx_Pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        public const string AU_Phone_Number_RegEx_Pattern = @"(^1300\d{6}$)|(^1800|1900|1902\d{6}$)|(^0[2|3|7|8]{1}[0-9]{8}$)|(^13\d{4}$)|(^04\d{2,3}\d{6}$)";
        public const string AU_PostCode_RegEx_Pattern = @"^(?:(?:[2-8]\d|9[0-7]|0?[28]|0?9(?=09))(?:\d{2}))$";
        public const string Strong_Password_RegEx_Pattern = @"(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$";
    }
}
