using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using UnityEngine.UI;

namespace Commands
{
    public class ChangeRCommand : ICommand
    {
        private Image _emptyImage;
        private float _colorChangeValue;
        public ChangeRCommand(Image image, float colorChangeValue)
        {
            
            _emptyImage = image;
            _colorChangeValue = colorChangeValue;
        }
        public void Execute()
        {
            _emptyImage.color = new Color(_emptyImage.color.r - _colorChangeValue, _emptyImage.color.g, _emptyImage.color.b);
        }
        public void Undo()
        {
            _emptyImage.color = new Color(_emptyImage.color.r + _colorChangeValue, _emptyImage.color.g, _emptyImage.color.b);
        }
    }
}

