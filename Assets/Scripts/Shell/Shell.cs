using UnityEngine;
using System;

namespace Game {

    internal enum ShellNumber {
        First,
        Second,
        Third
    }

    [RequireComponent(typeof(BoxCollider2D))]
    internal sealed class Shell : MonoBehaviour {

        public static Action<ShellNumber> OnShellCollected;
        public static Action<AudioClip> OnPlaySound;

        [SerializeField] private ShellNumber _shellNumber;
        [SerializeField] private AudioClip _collected;
        
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.GetComponent<Player>()) {
                OnPlaySound?.Invoke(_collected);
                OnShellCollected?.Invoke(_shellNumber);
                Destroy(gameObject);
            }
        }

    }
}