using UnityEngine;
using System; 

namespace Game {

    internal sealed class Fishes : MonoBehaviour, ITriggerActivator {

        [SerializeField] private GameObject _fish;
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

        public static event Action<bool, int> OnFishActivated = null;        

        private bool _activate = false;

        private void Awake()
        {
            if (_isMainMenuFish) _activate = true;
        }

        private void OnEnable()
        {
            DesactivateLimits.OnLevelChange += TurnOffLimits;
        }

        private void OnDisable()
        {
            DesactivateLimits.OnLevelChange += TurnOffLimits;
        }

        private void Update() {

            if (_activate && _fish != null) {

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

            _fish.transform.rotation = new Quaternion(_fish.transform.rotation.x, _fish.transform.rotation.y, _rotation, _fish.transform.rotation.w);

            if (_fish.transform.rotation.z > _maxRotationAngle) _rotationDirection = false;

            
        }

        private void NegativeRotation() {

            _rotation -= 0.4f * Time.deltaTime;

            if (_fish.transform.rotation.z < -_maxRotationAngle) _rotationDirection = true;

            _fish.transform.rotation = new Quaternion(_fish.transform.rotation.x, _fish.transform.rotation.y, _rotation, _fish.transform.rotation.w);
        }

        private void ForwardMovement() {

            _fish.transform.Translate(-_fish.transform.right * (_speed * Time.deltaTime), 0.0f);
        }

        private void RotationRandomizer() {

            _maxRotationAngle = UnityEngine.Random.Range(0.2f, 0.6f);

            _rotationFactor = UnityEngine.Random.Range(0.2f, 0.6f);

            _timeToRandomizeValues = UnityEngine.Random.Range(0.2f, 1.0f);
        }

        public void ActivateObject()
        {

            _activate = true;

            if (_fish.tag == "EnemigoEstrella") {
                
                OnFishActivated?.Invoke(_activate, ID);
            }
        }

        private void TurnOffLimits()
        {

            if (_fish != null)
                _fish.SetActive(false);
        }

    }
}