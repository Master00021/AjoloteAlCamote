using UnityEngine;

namespace Game {

    internal sealed class GameMusic : MonoBehaviour {

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        private void OnEnable() {
            GameLifeCycle.OnGamePause += PauseMusic;
            GameLifeCycle.OnGameUnPaused += UnPauseMusic;
        }

        private void OnDisable() {
            GameLifeCycle.OnGamePause -= PauseMusic;
            GameLifeCycle.OnGameUnPaused -= UnPauseMusic;
        }

        private void Start() {
            if (_audioSource == null) {
                Debug.Log("A menos que estes en el MainMenu, el AudioSource del GameMusic es nulo");
                return;
            }
            _audioSource.PlayOneShot(_audioClip);
        }

        private void PauseMusic() {
            _audioSource.Pause();
        }

        private void UnPauseMusic() {
            _audioSource.UnPause();
        }

    }
}