using System.Collections;
using UnityEngine;

namespace Game {

    internal sealed class BolsaBasura : Obstacle {

        [SerializeField, Range(1.0f, 10.0f)] private float _waveAmplitude;
        [SerializeField, Range(1.0f, 10.0f)] private float _frequence;
        [SerializeField] private float _forwardSpeed;

        public override void ActivateObject() {
            StartCoroutine(CO_VerticalMovement());
        }

        private IEnumerator CO_VerticalMovement() {
            while (true) {
                float movementY = Mathf.Sin(Time.time * _frequence) * _waveAmplitude * Time.deltaTime;

                var velocity = new Vector2(transform.position.x, movementY);
                transform.position = velocity;

                yield return null;
            }
        }

    }
}