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
                float movementY = Mathf.Sin(Time.time * _frequence) * _waveAmplitude;

                var velocity = new Vector3(0.0f, movementY);
                transform.Translate(Time.deltaTime * velocity, Space.World);

                yield return null;
            }
        }

    }
}