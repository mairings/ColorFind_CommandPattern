using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class ExampleImageController : MonoBehaviour
    {
        private Image _image;

        private void Awake()
        {
            Init();    
        }

        private void Init()
        {
            _image = GetComponent<Image>();
        }

        public void GenerateRandomColor()
        {
            _image.color = new Color(UnityEngine.Random.Range(0f, 1f),
                                            UnityEngine.Random.Range(0f, 1f),
                                            UnityEngine.Random.Range(0f, 1f));
        }

    }
}
