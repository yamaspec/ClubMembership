using System.ComponentModel;  // Elements to achieve loose coupling.

namespace EmployeeComponent
{
    // Data which is going to be displayed to the User.
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Id { get; set; }
        private string _firstName = string.Empty;
        public string FirstName
        { 
            get { return _firstName; } 
            set 
            { 
                if (_firstName == value)
                {
                    return;
                }
                _firstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public char Gender { get; set; }
        public bool IsManager { get; set; }

        private void NotifyPropertyChanged(string propertyName)
        { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
