using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;
using System;

namespace ClubMembershipApplication.Views
{
    public class WelcomeUserView:IView
    {
        User _user = null;
        public IFieldValidator FieldValidator => null;

        public WelcomeUserView(User user)
        {
            _user = user;
        }

        public void RunView()
        {
            Console.Clear();
            CommonOutputText.WriteMainHeading();
            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.Write($"Hi {_user.FirstName}!!{Environment.NewLine}Welcome to the Cycling Club!!");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
            Console.Write($" {Environment.NewLine}");
            Console.ReadKey();
        }
    }
}
