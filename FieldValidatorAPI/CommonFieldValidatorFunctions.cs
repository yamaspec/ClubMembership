using System;
using System.Text.RegularExpressions;

namespace FieldValidatorAPI
{
    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);
    public delegate bool PatternMatchValidDel(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);

    public class CommonFieldValidatorFunctions
    {
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLengthValidDel _stringLengthValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternMatchValidDel _patternMatchValidDel = null;
        private static CompareFieldsValidDel _compareFieldsValidDel = null;

        public static RequiredValidDel RequiredFieldValidDel
        {
            get
            {
                if (_requiredValidDel == null)
                {
                    _requiredValidDel = new RequiredValidDel(RequiredFieldValid);
                }
                return _requiredValidDel;
            }
        }

        public static StringLengthValidDel StringFieldLengthValidDel
        {
            get
            {
                if (_stringLengthValidDel == null)
                {
                    _stringLengthValidDel = new StringLengthValidDel(StringFieldLengthValid);
                }
                return _stringLengthValidDel;
            }
        }

        public static DateValidDel DateFieldValidDel
        {
            get
            {
                if (_dateValidDel == null)
                {
                    _dateValidDel = new DateValidDel(DateFieldValid);
                }
                return _dateValidDel;
            }
        }

        public static PatternMatchValidDel PatternMatchFieldValidDel
        {
            get
            {
                if (_patternMatchValidDel == null)
                {
                    _patternMatchValidDel = new PatternMatchValidDel(PatternMatchFieldValid);
                }
                return _patternMatchValidDel;
            }
        }

        public static CompareFieldsValidDel ComparisonFieldValidDel
        {
            get
            {
                if (_compareFieldsValidDel == null)
                {
                    _compareFieldsValidDel = new CompareFieldsValidDel(ComparisonFieldValid);
                }
                return _compareFieldsValidDel;
            }
        }

        private static bool RequiredFieldValid(string fieldVal)
        {
            return !string.IsNullOrEmpty(fieldVal);
        }
        private static bool StringFieldLengthValid(string fieldVal, int min, int max)
        {
            return (!string.IsNullOrEmpty(fieldVal) && fieldVal.Length >= min && fieldVal.Length <= max);
        }
        private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
        {
            return (DateTime.TryParse(dateTime, out validDateTime));
        }
        private static bool PatternMatchFieldValid(string fieldVal, string regularExpressionPattern)
        {
            Regex regex = new Regex(regularExpressionPattern);
            return regex.IsMatch(fieldVal);
        }
        private static bool ComparisonFieldValid(string field1, string field2)
        {
            return field1.Equals(field2);
        }
    }
}
