using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ColorChangeData", menuName ="ColorFind/ColorChangeData")]
    public class CD_ColorChangeData : ScriptableObject
    {
        public float ColorChangeValue;
        public float RequiredSameValue;
        public float UndoCountLimit;
    }
}

