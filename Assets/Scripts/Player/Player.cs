using UnityEngine;
using System;

namespace Game {

    [RequireComponent(typeof(Rigidbody2D))]
    internal sealed class Player : MonoBehaviour {

        public static Action OnPlayerDeath;

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _swimForce = 40.0f;
        [SerializeField] private float _maxVelocity = 13.0f;

        private void Update() {      
            if (Input.GetKey(KeyCode.Space)) {
                _rigidbody.AddForce(_swimForce * Time.deltaTime * transform.up);
            }

            if (_rigidbody.velocity.magnitude > _maxVelocity) {
                _rigidbody.velocity = _rigidbody.velocity.normalized * _maxVelocity;
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.TryGetComponent<ITriggerActivator>(out var trigger)) {
                trigger.ActivateObject();
            }

            if (other.GetComponent<Obstacle>()) {
                OnPlayerDeath?.Invoke();
                gameObject.SetActive(false);
            }
        }

    }
}