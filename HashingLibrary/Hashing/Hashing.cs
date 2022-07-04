namespace HashingLibrary.Hashing {
    public class Hashing {
        public async Task<string> GetChecksum(HashingAlgorithms hashingAlgorithm, string filename) {
            using (var hasher = System.Security.Cryptography.HashAlgorithm.Create(hashingAlgorithm.ToString())) {
                using (var stream = File.OpenRead(filename)) {
                    var hash = await hasher.ComputeHashAsync(stream);
                    return await BitesToString(hash);
                }
            }
        }

        private async Task<string> BitesToString(Byte[] bytes) {
            return await Task.Run(() => BitConverter.ToString(bytes).Replace("-", ""));
        }
    }
}
