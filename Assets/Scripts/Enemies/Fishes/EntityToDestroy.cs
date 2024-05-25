using UnityEngine;

namespace Game {

    [RequireComponent(typeof(BoxCollider2D))]
    internal sealed class EntityToDestroy : MonoBehaviour, IDestroyable {

        [SerializeField] private GameObject _objectToDestroy;
    
        public void Destroy() {
            Destroy(_objectToDestroy);
        }
    
    }
}

