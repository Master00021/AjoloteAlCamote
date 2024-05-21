using UnityEngine;
using System;

namespace Game {

    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    internal sealed class Player : MonoBehaviour {

        public static Action OnPlayerDeath;

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.TryGetComponent<ITriggerActivator>(out var trigger)) {
                trigger.ActivateObject();
            }

            if (other.GetComponent<Obstacle>()) {
                OnPlayerDeath?.Invoke();
                Death();
            }
        }

        internal void Death() {
            OnPlayerDeath?.Invoke();
            gameObject.SetActive(false);
        }

    }
}