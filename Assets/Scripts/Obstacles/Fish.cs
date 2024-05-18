using UnityEngine;
using System; 

namespace Game {

    internal sealed class Fish : MonoBehaviour, ITriggerActivator {

        [SerializeField] private float _speed;
        [SerializeField] private float _timeToRandomizeValues;        

        private bool _rotationDirection = true; // Positivo
        private float _rotation;
        private float _rotationFactor = 0.4f;
        private float _maxRotationAngle = 0.3f;

        [SerializeField] private GameObject _star;
        [SerializeField] private bool _isStar;
        [SerializeField] private bool _isEnemy;
        [SerializeField] private bool _isMainMenuFish;
        [SerializeField] private int ID;

        private bool _activate = false;

        private void Awake()
        {
            if (_isMainMenuFish) _activate = true;
        }

        private void Update() {

            if (_activate) {

                _timeToRandomizeValues -= Time.deltaTime;

                if (_timeToRandomizeValues <= 0.0f) {

                    RotationRandomizer();

                    _timeToRandomizeValues = 0.5f;
                }

                if (_rotationDirection) {
                    
                    PositiveRotation();                    
                }

                if (!_rotationDirection) {
                    
                    NegativeRotation();                    
                }

                ForwardMovement();

                if (!_isEnemy && !_isStar)
                {

                    //_fish.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }

        private void PositiveRotation() {

            _rotation += _rotationFactor * Time.deltaTime;

            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, _rotation, transform.rotation.w);

            if (transform.rotation.z > _maxRotationAngle) _rotationDirection = false;

            
        }

        private void NegativeRotation() {

            _rotation -= 0.4f * Time.deltaTime;

            if (transform.rotation.z < -_maxRotationAngle) _rotationDirection = true;

            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, _rotation, transform.rotation.w);
        }

        private void ForwardMovement() {

            transform.Translate(-transform.right * (_speed * Time.deltaTime), 0.0f);
        }

        private void RotationRandomizer() {

            _maxRotationAngle = UnityEngine.Random.Range(0.2f, 0.6f);

            _rotationFactor = UnityEngine.Random.Range(0.2f, 0.6f);

            _timeToRandomizeValues = UnityEngine.Random.Range(0.2f, 1.0f);
        }

        public void ActivateObject()
        {

            _activate = true;

        }

    }
}