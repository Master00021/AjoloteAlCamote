
namespace Game {

    internal sealed class LevelShells : LevelDataHandler {

        private void OnEnable() {
            Shell.OnShellCollected += ShellCollected;
        } 

        private void OnDisable() {
            Shell.OnShellCollected -= ShellCollected;
        } 

        private void ShellCollected(ShellNumber shellNumber) {
            if (shellNumber == ShellNumber.First) {
                _LevelData.FirstShell = true;
            }

            if (shellNumber == ShellNumber.Second) {
                _LevelData.SecondShell = true;
            }

            if (shellNumber == ShellNumber.Third) {
                _LevelData.ThirdShell = true;
            }
        }
        
    }
}