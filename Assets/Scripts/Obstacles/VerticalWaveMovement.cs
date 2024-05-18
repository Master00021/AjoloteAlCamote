using System.Collections;
using UnityEngine;

namespace Game {

    internal sealed class VerticalWaveMovement : Obstacle {

        [SerializeField, Range(1.0f, 10.0f)] private float _waveAmplitude;
        [SerializeField, Range(1.0f, 10.0f)] private float _frequence;

        protected override void OnActivateObject() {
            StartCoroutine(CO_VerticalMovement());
        }

        private IEnumerator CO_VerticalMovement() {
            while (true) {
                float movementY = Mathf.Sin(Time.time * _frequence) * _waveAmplitude * Time.deltaTime;

                var velocity = new Vector2(0.0f, movementY);
                transform.position *= velocity;

                yield return null;
            }
        }

    }
}