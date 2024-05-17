using UnityEngine;

namespace Game {

    [CreateAssetMenu]
    internal sealed class Levels : ScriptableObject {
        // Cada nivel tiene que tener sus propias estrellas
        // Cada nivel tiene que tener su propio porcentaje de completado
        // Cada nivel tiene que tener una variable que diga si esta completado o no
        // Cada nivel tiene que tener una dificultad

        [SerializeField] internal int _levelID;
        [SerializeField] internal int _stars;
        [SerializeField] internal int _percentage;
        [SerializeField] internal bool _completed;
        [SerializeField] internal string _difficulty;

    }
}