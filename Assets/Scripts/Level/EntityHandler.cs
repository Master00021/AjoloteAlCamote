using UnityEngine;

namespace Game {

    [RequireComponent(typeof(BoxCollider2D))]
    internal sealed class EntityHandler : MonoBehaviour {

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.TryGetComponent<IDestroyable>(out var destroyable)) {
                destroyable.Destroy();
            }

            if (other.TryGetComponent<Player>(out var player)) {
                player.Death();
            }
        }

    }
}