using UnityEngine;
using TMPro;

namespace Game {

    internal sealed class GameOverUI : GameUI {

        [SerializeField] private GameObject _uiToActivate;
        [SerializeField] private TextMeshProUGUI _percentage;
        [SerializeField] private LevelData _levelData;

        protected override void OnEnable() {
            base.OnDisable();

            Level.OnLevelEntry += GetCurrentLevel;
            Player.OnPlayerDeath += OnActivateUI;

            OnDeactivateUI();
        }

        protected override void OnDisable() {
            base.OnDisable();

            Level.OnLevelEntry -= GetCurrentLevel;
            Player.OnPlayerDeath -= OnActivateUI;
        }

        private void GetCurrentLevel(LevelData levelData) {
            _levelData = levelData;
        }

        private void PercentageObtained() {
            if (_levelData.Percentage > 99.0f) {
                _levelData.Percentage = 100.0f;
            }

            _percentage.text = _levelData.Percentage.ToString("0") + "%";
        }

        protected override void OnActivateUI() {
            PercentageObtained();
            _uiToActivate.SetActive(true);
        }

        protected override void OnDeactivateUI() {
            _uiToActivate.SetActive(false);
        }

    }
}

