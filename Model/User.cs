using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mod08.Model
{
    public class User : INotifyPropertyChanged
    {
        private int _presentCount;
        private int _absentCount;

        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Course { get; set; }

        public string FullName => $"{Firstname} {Lastname}";

        public string LastEnrolledTerm { get; set; } // e.g. "First Term, 2024-25"
        public string CourseYear { get; set; }

        public int PresentCount
        {
            get => _presentCount;
            set
            {
                if (_presentCount != value)
                {
                    _presentCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public int AbsentCount
        {
            get => _absentCount;
            set
            {
                if (_absentCount != value)
                {
                    _absentCount = value;
                    OnPropertyChanged();
                }
            }
        }

        // New Property for Ledger Entries
        private List<Ledger> _ledgers;
        public List<Ledger> Ledgers
        {
            get => _ledgers;
            set
            {
                if (_ledgers != value)
                {
                    _ledgers = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Ledger Model
    public class Ledger
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string SchoolYear { get; set; }
        public string Term { get; set; }
        public DateTime DatePaid { get; set; }
        public string Particulars { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
        public decimal OldAccounts { get; set; }
    }
}
