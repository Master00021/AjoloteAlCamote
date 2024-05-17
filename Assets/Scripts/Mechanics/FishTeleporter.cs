using UnityEngine;

namespace Game {

    internal sealed class FishTeleporter : MonoBehaviour {

        [SerializeField] private GameObject _newSpawnPoint;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstaculo"))
            {
                collision.gameObject.transform.position = _newSpawnPoint.transform.position;
            }
        }

    }
}