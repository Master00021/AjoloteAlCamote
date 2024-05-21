using UnityEngine;

namespace Game {

    internal sealed class VictoryUI : GameUI {    

        [SerializeField] private LevelData _levelData;
        [SerializeField] private GameObject[] _shells;

        private void OnEnable(){
            Level.OnLevelEntry += GetCurrentLevel;
            LevelGoal.OnLevelComplete += ShellCollected;
        }

        private void OnDisable() {
            Level.OnLevelEntry -= GetCurrentLevel;
            LevelGoal.OnLevelComplete -= ShellCollected;
        } 

        private void GetCurrentLevel(LevelData levelData) {
            _levelData = levelData;
        }

        private void ShellCollected() {
            if (_levelData.FirstShell) {
                _shells[0].SetActive(true);
            }

            if (_levelData.SecondShell) {
                _shells[1].SetActive(true);
            }

            if (_levelData.ThirdShell) {
                _shells[2].SetActive(true);
            }
        }

        protected override void OnActivateUI() {
            ShellCollected();
        }

        protected override void OnDeactivateUI() {
            for (int i = 0; i < _shells.Length; i++) {
                _shells[i].SetActive(false);
            }
        }

    }  
}