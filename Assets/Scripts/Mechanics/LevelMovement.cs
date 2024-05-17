using UnityEngine;
using System;

namespace Game {

    internal sealed class LevelMovement : MonoBehaviour {

        [SerializeField] public float _velocidadNivel;
        [SerializeField] private float _increaseSpeedFactor;
        [SerializeField] private float _metrosRecorridosEnPantalla;
        [SerializeField] private float _multiplicadorMetros;
        [SerializeField] private float _distanciaDefinidaParaAumentarVelocidad;

        [SerializeField] private float _DificultadNivel;

        [SerializeField] private Vector3 _distanciaReal;

        // La velocidad limite jugable esta alrededor de los 0.4f, por lo que ese sera el limite
        [SerializeField] private float _limiteVelocidadNivel;

        public static Action<float> OnDistanceChanged = null;

        private bool _pauseAll;

        private void Awake()
        {
            _pauseAll = true;
        }

        private void OnEnable()
        {

            LevelManager.OnLevelCompletedForLevelMovement += PauseAll;
        }

        private void OnDisable()
        {

            LevelManager.OnLevelCompletedForLevelMovement -= PauseAll;
        }

        public float GetVelocidadNivel()
        {

            return _velocidadNivel;
        }


        private void LateUpdate()
        {

            if (_pauseAll)
            {

                // Hace que el mapa se mueva hacia atras
                transform.position -= new Vector3(_velocidadNivel, 0.0f, 0.0f) * Time.deltaTime;

                // Calcula la distancia real, restando el punto cero cero con la posicion del objeto actual
                _distanciaReal = new Vector3(0.0f, 0.0f, 0.0f) - transform.position;

                // Funcion que genera los metros recorridos mostrados en pantalla
                _metrosRecorridosEnPantalla = 1.0f * Mathf.Pow(_distanciaReal.x, 1.1f) * _multiplicadorMetros;

                OnDistanceChanged?.Invoke(_metrosRecorridosEnPantalla);

                // Si la distancia recorida es mayor a la distancia definida para aumentar la velocidad
                if (_distanciaReal.x >= _distanciaDefinidaParaAumentarVelocidad && _velocidadNivel <= _limiteVelocidadNivel)
                {

                    // Se define la distancia en la que se volvera a aumentar la velocidad
                    _distanciaDefinidaParaAumentarVelocidad += _distanciaReal.x * _DificultadNivel;

                    // Aumenta la velocidad del nivel segun un factor
                    _velocidadNivel *= _increaseSpeedFactor;

                    Vector3 posicion = new Vector3(_distanciaDefinidaParaAumentarVelocidad, 0.0f);
                }

                if (_velocidadNivel > _limiteVelocidadNivel) _velocidadNivel = _limiteVelocidadNivel;
            }
        }
        private void PauseAll()
        {

            _pauseAll = false;

            Time.timeScale = 0.0f;
        }

    }
}