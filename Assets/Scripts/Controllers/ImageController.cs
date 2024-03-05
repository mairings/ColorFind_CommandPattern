using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Managers;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class ImageController : MonoBehaviour
    {
        [SerializeField] Image _empty, _example;
        [SerializeField] UIManager _UiManager;
    
        private void OnEnable()
        {
            SubscribeEvents();
        }
        private void SubscribeEvents()
        {
            ColorSignals.Instance.onCalculateEuclideanDistance += OnCalculateEuclideanDistance;
            ColorSignals.Instance.onGenerateRandomColor += OnGenerateRandomColor;
        }
        public float OnCalculateEuclideanDistance()
        {
            Color color1 = _example.color;
            Color color2 = _empty.color;

            float deltaR = color1.r - color2.r;
            float deltaG = color1.g - color2.g;
            float deltaB = color1.b - color2.b;

            return Mathf.Sqrt(deltaR * deltaR + deltaG * deltaG + deltaB * deltaB);
        }
        private void UnSubscribeEvent()
        {
            ColorSignals.Instance.onCalculateEuclideanDistance -= OnCalculateEuclideanDistance;
            ColorSignals.Instance.onGenerateRandomColor -= OnGenerateRandomColor;
        }
        private void OnDisable()
        {
            UnSubscribeEvent();
        }

        public void ResetEmptyColor()
        {
            StartCoroutine("ResetColorIE");
        }
        IEnumerator ResetColorIE()
        {
            yield return new WaitForSeconds(2);
            OnGenerateRandomColor();
            _empty.color = new Color(1, 1, 1);
        }
        
        public void OnGenerateRandomColor()
        {
            _example.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}

