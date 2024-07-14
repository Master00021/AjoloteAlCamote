using UnityEngine;
using System;
using TMPro;

namespace Game {

    internal sealed class LevelMenuUI : MonoBehaviour {

        public static Action OnLoadData;
        
        [SerializeField] private LevelData _levelData;
        [SerializeField] private TextMeshProUGUI _percentage;
        [SerializeField] private TextMeshProUGUI _completed;
        [SerializeField] private GameObject[] _shells;

        private void OnEnable() {
            OnLoadData?.Invoke();
            
            PercentageObtained();
            ShellCollected();
            Completed();
        }

        private void PercentageObtained() {
            if (_levelData.Percentage >= 99.0f) {
                Completed();
            }
            
            _percentage.text = _levelData.Percentage.ToString("0") + "%";
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

        private void Completed() {
            if (_levelData.Completed) {
                _percentage.gameObject.SetActive(false);
                _completed.gameObject.SetActive(true);


            }
        }

    }
}