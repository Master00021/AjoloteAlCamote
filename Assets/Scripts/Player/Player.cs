using System.Collections;
using UnityEngine;
using System;

namespace Game {

    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    internal sealed class Player : MonoBehaviour {

        public static Action OnPlayerDeath;

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _gravityIntensity = 2.93f;
        [SerializeField] private float _limitYSpeed;
        [SerializeField] private float _xSpeed;

        private const float ONE = 1.0f;

        private void OnEnable() {
            GameLifeCycle.OnGameStart += GameStarted;
        }

        private void OnDisable() {
            GameLifeCycle.OnGameStart -= GameStarted;
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

        private void GameStarted() {      
            StartCoroutine(Co_HorizontalMovement());
            StartCoroutine(CO_VerticalMovement());
        }

        private IEnumerator CO_VerticalMovement() {
            while (true) {
                float direction = Input.GetKey(KeyCode.Space) ? -ONE : ONE;
                float gravityForce = _gravityIntensity * direction;

                _rigidbody.gravityScale = gravityForce;

                float yVelocity = _rigidbody.velocity.y;

                if (yVelocity > _limitYSpeed) {
                    yVelocity = _limitYSpeed;
                }
                else if (yVelocity < -_limitYSpeed) {
                    yVelocity = -_limitYSpeed;
                }

                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, yVelocity);

                yield return null;
            }
        }

        private IEnumerator Co_HorizontalMovement() {
            while (true) {
                _rigidbody.velocity = new Vector2(_xSpeed, _rigidbody.velocity.y);

                yield return null;
            }
        }

    }
}