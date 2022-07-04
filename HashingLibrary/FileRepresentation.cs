using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HashingLibrary {
    public class FileRepresentation : INotifyPropertyChanged {
        private readonly string _fullName;
        private string _hash;

        public FileRepresentation(string fullName) {
            _fullName = fullName;
            _hash = String.Empty;
        }

        public string FullName { get { return _fullName; } }
        public string Hash {
            get { return _hash; }
            set {
                _hash = value;
                OnPropertyChanged("Hash");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
