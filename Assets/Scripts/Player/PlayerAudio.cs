using UnityEngine;

namespace Game {

    internal sealed class PlayerAudio : MonoBehaviour {

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _playerDeath;
        [SerializeField] private AudioClip _playerWin;

        private void OnEnable() {
            Player.OnPlayerDeath += PlayDeath;
            LevelGoal.OnLevelComplete += PlayerWin;
        }

        private void OnDisable() {
            Player.OnPlayerDeath -= PlayDeath;
            LevelGoal.OnLevelComplete -= PlayerWin;
        }

        private void PlayDeath() {
            _audioSource.PlayOneShot(_playerDeath);
        }

        private void PlayerWin() {
            _audioSource.PlayOneShot(_playerWin);
        }

    }
}