using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
namespace Extentions
{
    public static class Extentions
    {
        public static IEnumerator SendInfoMessage(this MonoBehaviour monoBehaviour, TextMeshProUGUI tmpui,string message, float delay)
        {
            tmpui.text = message;
            yield return new WaitForSeconds(delay);
            tmpui.text = "";
        }
    }
}

