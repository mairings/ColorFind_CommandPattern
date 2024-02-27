using UnityEngine;
using UnityEngine.Events;
using Keys;

namespace Signals
{
    public class ColorSignals : MonoBehaviour
    {
        public static ColorSignals Instance;

        private void Awake()
        {
            if (Instance != this && Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        //public UnityAction onColorCalculateEuclideanDistance = delegate { };

    }
}
