using UnityEngine;

namespace Game {

    internal sealed class GameAudio : MonoBehaviour {

        [SerializeField] private AudioSource _audioSource;

        public void PlaySound(AudioClip audioClip) {
            _audioSource.PlayOneShot(audioClip);
        }

    }
}