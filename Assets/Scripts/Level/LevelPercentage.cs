using UnityEngine;

namespace Game {

    internal sealed class LevelPercentage : LevelDataHandler {
    
        [SerializeField] private Transform _playerPos;
        [SerializeField] private Transform _levelEnd;

        private Transform _levelStart;
        private float _percentage;

        private void Awake() {
            _levelStart = _playerPos;
        }

        private void OnEnable() {
            LevelGoal.OnLevelComplete += CalculatePercentage;
            Player.OnPlayerDeath += CalculatePercentage;
        }

        private void OnDisable() {
            LevelGoal.OnLevelComplete -= CalculatePercentage;
            Player.OnPlayerDeath -= CalculatePercentage;
        }

        private void CalculatePercentage() {
            float totalDistance = _levelEnd.position.x - _levelStart.position.x;

            float distanceCovered = _playerPos.position.x - _levelStart.position.x;

            float percentage =  100.0f * (distanceCovered / totalDistance);

            _percentage = Mathf.Clamp(percentage, 0.0f, 100.0f);

            _LevelData.Percentage = _percentage;
        }

    }
}