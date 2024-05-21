using System.Collections;
using UnityEngine;

namespace Game {

    internal sealed class GenericMovement : Obstacle {

        [SerializeField] private float _verticalSpeed;
        [SerializeField] private float _rotationSpeed;

        protected override void OnActivateObject() {
            StartCoroutine(CO_Rotate());
            StartCoroutine(CO_Descend());
        }

        private IEnumerator CO_Rotate() {
            while (true) {
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, _rotationSpeed * Time.time);
                yield return null;
            }
        }

        private IEnumerator CO_Descend() {
            while (true) {
                transform.position += _verticalSpeed * Time.deltaTime * -Vector3.up;
                yield return null;
            }
        }

    }
}