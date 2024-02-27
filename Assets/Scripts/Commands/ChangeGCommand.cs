using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using UnityEngine.UI;
using Data;

namespace Commands
{
    public class ChangeGCommand : ICommand
    {
        private Image _emptyImage;
        private float _colorChangeValue;
        public ChangeGCommand(Image image, float colorChangeValue)
        {
            _emptyImage = image;
            _colorChangeValue = colorChangeValue;
        }

        public void Execute()
        {
            _emptyImage.color = new Color(_emptyImage.color.r, _emptyImage.color.g- _colorChangeValue, _emptyImage.color.b);
        }
        public void Undo()
        {
            _emptyImage.color = new Color(_emptyImage.color.r, _emptyImage.color.g + _colorChangeValue, _emptyImage.color.b);
        }

    }
}
