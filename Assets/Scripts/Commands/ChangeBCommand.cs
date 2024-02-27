using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using UnityEngine.UI;
using Data;

namespace Commands
{
    public class ChangeBCommand : ICommand
    {
        private Image _emptyImage;
        private float _colorChangeValue;
        public ChangeBCommand(Image image, float colorChangeValue)
        {
            _emptyImage = image;
            _colorChangeValue = colorChangeValue;
        }
        public void Execute()
        {
            _emptyImage.color = new Color(_emptyImage.color.r, _emptyImage.color.g, _emptyImage.color.b - _colorChangeValue);
        }

        public void Undo()
        {
            _emptyImage.color = new Color(_emptyImage.color.r, _emptyImage.color.g, _emptyImage.color.b + _colorChangeValue);
        }
    }
}

