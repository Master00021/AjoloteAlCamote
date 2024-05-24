using UnityEngine;

namespace Game {

    internal sealed class PlayerAudio : MonoBehaviour {

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _playerDeath;

        private void OnEnable() {
            Player.OnPlayerDeath += PlayDeath;
        }

        private void OnDisable() {
            Player.OnPlayerDeath -= PlayDeath;
        }

        private void PlayDeath() {
            _audioSource.PlayOneShot(_playerDeath);
        }

    }
}