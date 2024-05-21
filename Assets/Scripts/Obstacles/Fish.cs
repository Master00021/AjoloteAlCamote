using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace Game {

    internal sealed class Fish : MonoBehaviour, ITriggerActivator {

        [SerializeField] private float _horizontalSpeed;
        [SerializeField] private float _rotationIntensity;
        [MinMaxSlider(15.0f, 50.0f)]
        [SerializeField] private Vector2 _rotationAngleRange;

        private float _direction;
        private float _currentZAngle;

        private void Start() {
            ActivateObject();
        }

        public void ActivateObject() {
            StartCoroutine(CO_HorizontalMovement());
            StartCoroutine(CO_Direction());
            StartCoroutine(CO_Rotate());
        }

        private IEnumerator CO_HorizontalMovement() {
            while (true) {
                transform.Translate(_horizontalSpeed * Time.deltaTime * -transform.right, Space.World);
                yield return null;
            }
        }

        private IEnumerator CO_Rotate() {
            while (true) {
                float rotationAmount = _rotationIntensity * _direction * Time.deltaTime;
                var rotationVector = new Vector3(0.0f, 0.0f, rotationAmount);

                transform.Rotate(rotationVector);

                float zAngle = transform.eulerAngles.z;
                _currentZAngle = NormalizeAngle(zAngle);

                yield return null;
            }
        }

        private IEnumerator CO_Direction() {
            bool rise = Random.value > 0.5f;
            _direction = rise ? 1.0f : -1.0f;

            while (true) {
                float randomRotationAngle = Random.Range(_rotationAngleRange.x, _rotationAngleRange.y);

                if (Mathf.Abs(_currentZAngle) > randomRotationAngle) {
                    _direction = rise ? 1.0f : -1.0f;
                    rise = !rise;
                }

                yield return null;
            }
        }

        private float NormalizeAngle(float angle) {
            float oneRevolution = 360.0f;
            float halfRevolution = 180.0f;

            if (angle >= oneRevolution) {
                angle -= oneRevolution;
            }

            if (angle > halfRevolution) {
                angle -= oneRevolution;
            }

            return angle;
        }

    }
}