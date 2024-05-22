using UnityEngine;
using System;

namespace Game {

    internal enum ShellNumber {
        First,
        Second,
        Third
    }

    [RequireComponent(typeof(BoxCollider2D), typeof(AudioSource))]
    internal sealed class Shell : MonoBehaviour {

        public static Action<ShellNumber> OnShellCollected;

        [SerializeField] private ShellNumber _shellNumber;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _collected;
        
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.GetComponent<Player>()) {
                _audioSource.PlayOneShot(_collected);
                OnShellCollected?.Invoke(_shellNumber);
                Destroy(gameObject);
            }
        }

    }
}