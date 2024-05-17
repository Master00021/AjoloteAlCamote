using UnityEngine;
using System;
using TMPro;

namespace Game {

    internal sealed class ResultDistance : MonoBehaviour {

        [SerializeField] private TextMeshProUGUI _gameOverText, _victoryText;

        private void OnEnable() {

            LevelMovement.OnDistanceChanged += DistanceChanged;
        }

        private void DistanceChanged(float metrosRecorridos) {

            _gameOverText.text = Convert.ToInt32(metrosRecorridos).ToString() + "m";
            _victoryText.text = Convert.ToInt32(metrosRecorridos).ToString() + "m";
        }

    }
}