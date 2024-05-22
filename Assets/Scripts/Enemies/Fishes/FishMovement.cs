using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace Game {

    [RequireComponent(typeof(BoxCollider2D))]
    internal sealed class FishMovement : MonoBehaviour, ITriggerActivator  {

        [SerializeField] private float _horizontalSpeed;
        [SerializeField] private float _horizontalIncrease;
        [SerializeField] private float _rotationIntensity;
        [MinMaxSlider(20.0f, 60.0f)]
        [SerializeField] private Vector2 _rotationAngleRange;

        private float _currentZAngle;
        private float _direction;

        public void ActivateObject() {
            StartCoroutine(CO_HorizontalMovement());
            StartCoroutine(CO_Direction());
            StartCoroutine(CO_Rotate());
        }

        private IEnumerator CO_HorizontalMovement() {
            while (true) {
                _horizontalSpeed += _horizontalIncrease * Time.deltaTime;

                transform.Translate(_horizontalSpeed * Time.deltaTime * -transform.right, Space.World);
                yield return null;
            }
        }

        private IEnumerator CO_Rotate() {
            while (true) {
                float rotationAmount = _rotationIntensity * _direction * Time.deltaTime;
                var rotationVector = new Vector3(transform.rotation.x, transform.rotation.y, rotationAmount);

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

                    float timeToWait = 0.01f * _currentZAngle;
                    yield return new WaitForSeconds(timeToWait);
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