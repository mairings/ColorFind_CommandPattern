using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Managers;
using Signals;

namespace Controllers
{
    public class EmptyImageController : MonoBehaviour
    {
        private Image _image;
        [SerializeField] Image _exampleImage;
        [SerializeField] ExampleImageController _exampleImageController;
        [SerializeField] UIManager _uiManager;
        private void Awake()
        {
            Init();    
        }
        private void Start()
        {
        }
        private void Init()
        {
            _image = GetComponent<Image>();
        }
        public void ResetColor()
        {
            StartCoroutine("ResetColorIE");
        }

        IEnumerator ResetColorIE()
        {
            yield return new WaitForSeconds(2);
            _exampleImageController.GenerateRandomColor();
            _image.color = new Color(1, 1, 1);
        }
        public void CalculateEuclideanDistance()
        {
            Color color1 = _exampleImage.color;
            Color color2 = _image.color;

            float deltaR = color1.r - color2.r;
            float deltaG = color1.g - color2.g;
            float deltaB = color1.b - color2.b;

            _uiManager.ResultColorCalculate = Mathf.Sqrt(deltaR * deltaR + deltaG * deltaG + deltaB * deltaB);
          
        }
    }
}
