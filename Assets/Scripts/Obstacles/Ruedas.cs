using UnityEngine;

namespace Game {

    internal sealed class Ruedas : MonoBehaviour, ITriggerActivator {

        // Enemigo
        [SerializeField] private float _velocidadRotacion;
        [SerializeField] private GameObject _wheel;

        private float _time = 0.0f;
        private bool _activate = false;

        // Sistema de desactivacion
        [SerializeField] private bool _desactivable;
        [SerializeField] private GameObject[] _desactivableStones;

        private void FixedUpdate() {

            if (_activate) {

                _time += Time.deltaTime;

                if (_time >= 360.0f) {

                    _time = 0.0f;
                }

                _wheel.transform.rotation = Quaternion.Euler(0.0f, 0.0f, _time * _velocidadRotacion);
            }
        }

        public void ActivateObject() {

            _activate = true;    

            // Suscripcion a evento
            Player.OnEnemyDesactivated += DesactivateEnemy;
        }

        private void DesactivateEnemy() {

            if (_desactivable) {

                for (int i = 0; i < _desactivableStones.Length; i++) {

                    print(_desactivableStones[i]);

                    _desactivableStones[i].GetComponent<CircleCollider2D>().enabled = false;
                    _desactivableStones[i].GetComponent<SpriteRenderer>().color = new Color(0,0,1,0.75f);

                    Player.OnEnemyDesactivated -= DesactivateEnemy;
                }
            }
        }  

    }
}