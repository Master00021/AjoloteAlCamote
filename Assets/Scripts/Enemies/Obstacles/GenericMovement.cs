using System.Collections;
using UnityEngine;

namespace Game {

    [RequireComponent(typeof(BoxCollider2D))]
    internal sealed class GenericMovement : Obstacle {

        [SerializeField] private float _verticalSpeed;
        [SerializeField] private float _rotationSpeed;

        protected override void OnActivateObject() {
            StartCoroutine(CO_Rotate());
            StartCoroutine(CO_Descend());
        }

        private IEnumerator CO_Rotate() {
            float time = 0.0f;
            while (true) {
                time += Time.deltaTime;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, _rotationSpeed * time);
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