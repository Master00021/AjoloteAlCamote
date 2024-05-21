using UnityEngine;
using TMPro;

namespace Game {

    internal sealed class ResultDistance : MonoBehaviour {

        [SerializeField] private TextMeshProUGUI _gameOverText;
        [SerializeField] private TextMeshProUGUI _victoryText;

        private void OnEnable() {
            
        }

        private void OnDisable() {

        }

        private void DistanceChanged(float metrosRecorridos) {
            _gameOverText.text = metrosRecorridos.ToString("0000") + "m";
            _victoryText.text = metrosRecorridos.ToString("0000") + "m";
        }

    }
}