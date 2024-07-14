using UnityEngine;

namespace Game {

    internal sealed class DataHandler : MonoBehaviour {

        [SerializeField] private LevelData _levelOneData;
        [SerializeField] private LevelData _levelTwoData;
        [SerializeField] private LevelData _levelThreeData;

        private void OnEnable() {
            GameUI.OnSaveData += OnSaveLevelData;
            LevelMenuUI.OnLoadData += OnLoadLevelData;
        }

        private void OnDisable() {
            GameUI.OnSaveData -= OnSaveLevelData;
            LevelMenuUI.OnLoadData -= OnLoadLevelData;
        }

        private void OnSaveLevelData() {
            DataSystem.SaveLevelData(_levelOneData);
            DataSystem.SaveLevelData(_levelTwoData);
            DataSystem.SaveLevelData(_levelThreeData);
        }

        private void OnLoadLevelData() {
            DataSystem.LoadLevelData(_levelOneData);
            DataSystem.LoadLevelData(_levelTwoData);
            DataSystem.LoadLevelData(_levelThreeData);
        }

    }
}