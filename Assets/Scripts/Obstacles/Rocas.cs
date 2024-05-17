using UnityEngine;

namespace Game {

    internal sealed class Rocas : MonoBehaviour, ITriggerActivator {

        [SerializeField] private bool _goUp;
        [SerializeField] private float _speed;
        [SerializeField] private GameObject _rocks;

        private float _time;
        internal bool _activate = false;

        // Sistema de desactivacion
        [SerializeField] private bool _desactivable;

        private void FixedUpdate() {

            if (_activate && _rocks != null) {

                _time += Time.deltaTime;

                if (_goUp) _rocks.transform.localPosition = new Vector3(_rocks.transform.localPosition.x, _time * _speed);
                else _rocks.transform.localPosition = new Vector3(_rocks.transform.localPosition.x, -_time * _speed);    
            }
        }

        public void ActivateObject() {

            _activate = true;    

            // Suscripcion a evento
            Player.OnEnemyDesactivated += DesactivateEnemy;
        }

        private void DesactivateEnemy() {

            if (_desactivable) {

                _rocks.GetComponent<BoxCollider2D>().enabled = false;
                _rocks.GetComponent<SpriteRenderer>().color = new Color(0,0,1,0.75f);     

                Player.OnEnemyDesactivated -= DesactivateEnemy;           
            }
        } 

    }
}