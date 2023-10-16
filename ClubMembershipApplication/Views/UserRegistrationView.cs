﻿using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using System;

namespace ClubMembershipApplication.Views
{
    public class UserRegistrationView : IView
    {
        IFieldValidator _fieldValidator = null;
        IRegister _register = null;

        public IFieldValidator FieldValidator { get => _fieldValidator; }

        public UserRegistrationView(IRegister register, IFieldValidator fieldValidator)
        {
            _fieldValidator = fieldValidator;
            _register = register;
        }

        public void RunView()
        {
            string enterYourPasswordPrompt = 
                $"Please enter your password.{Environment.NewLine}" +
                $"Your password must contain at least 1 small-case letter{Environment.NewLine}" +
                $"1 capital letter, 1 digit, 1 special character{Environment.NewLine}" +
                $"The length should be between 6 - 10 characters{Environment.NewLine}";
            
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteRegistrationHeading();
            
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.EmailAddress] = GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please enter your Email Address: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.FirstName] = GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please enter your First Name: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.LastName] = GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please enter your Last Name: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.Password] = GetInputFromUser(FieldConstants.UserRegistrationField.Password, enterYourPasswordPrompt);
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PasswordCompare] = GetInputFromUser(FieldConstants.UserRegistrationField.PasswordCompare, "Please re-enter your password: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.DateOfBirth] = GetInputFromUser(FieldConstants.UserRegistrationField.DateOfBirth, "Please enter your Date of Birth (DD/MM/YYY): ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressFirstLine] = GetInputFromUser(FieldConstants.UserRegistrationField.AddressFirstLine, "Please enter your Address 1st line: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressSecondLine] = GetInputFromUser(FieldConstants.UserRegistrationField.AddressSecondLine, "Please enter your Address 2nd line: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressCity] = GetInputFromUser(FieldConstants.UserRegistrationField.AddressCity, "Please enter the city where you live: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PostCode] = GetInputFromUser(FieldConstants.UserRegistrationField.PostCode, "Please enter your address post code: ");
            
            RegisterUser();
        }

        private void RegisterUser()
        {
            _register.Register(_fieldValidator.FieldArray);
            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine("You have successfully registered. Please press any key to login.");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
        }

        private string GetInputFromUser(FieldConstants.UserRegistrationField field, string promptText)
        {
            string fieldVal = "";
            do
            {
                Console.WriteLine(promptText);
                fieldVal = Console.ReadLine();
            }
            while (!FieldValid(field, fieldVal));

            return fieldVal;
        }

        private bool FieldValid(FieldConstants.UserRegistrationField field, string fieldValue)
        {
            if (_fieldValidator.ValidatorDel((int)field, fieldValue, _fieldValidator.FieldArray, out string invalidMessage))
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine(invalidMessage);
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                return false;
            }
            return true;
        }
    }
}
