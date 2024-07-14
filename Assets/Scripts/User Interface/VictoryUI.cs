using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using TMPro;

namespace Game {

    internal sealed class VictoryUI : GameUI {    

        [SerializeField] private GameObject _uiToActivate;
        [SerializeField] private GameObject[] _shells;
        [SerializeField] private TextMeshProUGUI _percentage;
        [SerializeField] private LevelData _levelData;

        protected override void OnEnable(){
            base.OnEnable();

            Level.OnLevelEntry += GetCurrentLevel;
            LevelGoal.OnLevelComplete += ShellCollected;

            OnDeactivateUI();
        }

        protected override void OnDisable() {
            base.OnDisable();

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

        private void PercentageObtained() {
            if (_levelData.Percentage > 99.0f) {
                _levelData.Percentage = 100.0f;
            }

            _percentage.text = _levelData.Percentage.ToString("0") + "%";
        }

        public override void OnRestart() {
            StartCoroutine(CO_RestartLevel());
        }

        private IEnumerator CO_RestartLevel() {
            while (true) {
                yield return new WaitForSecondsRealtime(0.1f);
                
                SceneManager.LoadScene(_levelData.LevelName, LoadSceneMode.Single);
            }
        }

        protected override void OnActivateUI() {
            ShellCollected();
            PercentageObtained();
            _uiToActivate.SetActive(true);
        }

        protected override void OnDeactivateUI() {
            for (int i = 0; i < _shells.Length; i++) {
                _shells[i].SetActive(false);
            }

            _uiToActivate.SetActive(false);
        }

    }  
}