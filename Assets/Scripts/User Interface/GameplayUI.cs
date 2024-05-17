using UnityEngine;
using System;
using TMPro;

namespace Game {

    internal sealed class GameplayUI : MonoBehaviour {
        
        [SerializeField] private TextMeshProUGUI _currentDistance;

        private void OnEnable() => LevelMovement.OnDistanceChanged += CurrentDistance;
        private void OnDisable() => LevelMovement.OnDistanceChanged -= CurrentDistance;

        private void CurrentDistance(float currentDistance) {
            _currentDistance.text = currentDistance.ToString("0000") + "m";
        }

    }
}