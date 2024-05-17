using UnityEngine;

namespace Game {

    internal sealed class Botellas : Obstacle, ITriggerActivator {

        [SerializeField] private float _downSpeed;
        [SerializeField] private float _leftSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private bool _rotate;
        [SerializeField] private GameObject _bottle;

        private float _time;

        // Sistema de desactivacion
        [SerializeField] private bool _desactivable;

        private void FixedUpdate() {
            if (_bottle != null) {

                _time += Time.deltaTime;

                _bottle.transform.localPosition = new Vector3(_bottle.transform.localPosition.x, -_time * _downSpeed);

                LeftMovement();

                if (_time >= 360.0f) {

                _time = 0.0f;
            }

                if (_rotate) _bottle.transform.rotation = Quaternion.Euler(0.0f, 0.0f, _time * _rotationSpeed);
            }
        }

        public override void ActivateObject() {

        }

        private void LeftMovement() {
            _bottle.transform.Translate(-_bottle.transform.right * (_leftSpeed * Time.deltaTime), 0.0f);
        }

    }
}