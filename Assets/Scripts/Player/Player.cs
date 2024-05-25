using UnityEngine;
using System;

namespace Game {

    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    internal sealed class Player : MonoBehaviour {

        public static Action OnPlayerDeath;
        public static Action OnPause;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                OnPause?.Invoke();
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.TryGetComponent<ITriggerActivator>(out var trigger)) {
                trigger.ActivateObject();
            }
        }

        internal void Death() {
            OnPlayerDeath?.Invoke();
            gameObject.SetActive(false);
        }

    }
}