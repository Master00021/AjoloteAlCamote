using UnityEngine;

namespace Game {

    internal sealed class Troncos : MonoBehaviour, ITriggerActivator {

        [SerializeField] private float _speed;
        [SerializeField] private GameObject _trunk;
        
        private float _downValue;
        private bool _activate = false;

        // Sistema de desactivacion
        [SerializeField] private bool _desactivable;
        
        private void FixedUpdate() {

            if (_activate) {

                _downValue += Time.deltaTime;

                _trunk.transform.localPosition = new Vector3(_trunk.transform.localPosition.x, -_downValue * _speed);
            }       
        }

        public void ActivateObject() {

            _activate = true;

            // Suscripcion a evento
            Player.OnEnemyDesactivated += DesactivateEnemy;
        }

        private void DesactivateEnemy() {

            if (_desactivable) {

                _trunk.GetComponent<BoxCollider2D>().enabled = false;
                _trunk.GetComponent<SpriteRenderer>().color = new Color(0,0,1,0.75f);

                Player.OnEnemyDesactivated -= DesactivateEnemy;
            }
        }  

    }
}