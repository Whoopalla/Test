using HashingLibrary;
using HashingLibrary.Hashing;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace HashingApp.ViewModels {
    public class MainWindowViewModel {
        private HashingAlgorithms selectedAlgorithm;
        private Hashing hashing = new Hashing();

        public ObservableCollection<FileRepresentation> Files = new ObservableCollection<FileRepresentation>();

        public void AddNewFile(string path) {
            if (FileExists(path)) {
                Files.Add(new FileRepresentation(path));
            }
        }

        public async Task UpdateFilesInfo() {
            Parallel.ForEach(Files, async file => { file.Hash = await hashing.GetChecksum(selectedAlgorithm, file.FullName); });
        }

        private bool FileExists(string file) {
            return File.Exists(file);
        }
    }
}
