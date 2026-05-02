using TMPro;
using UnityEngine;

namespace Gnarly.LineInfo
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LineInfoItem : MonoBehaviour
    {
        public TMP_Text messageLabel;

        public void Init(string message)
        {
            messageLabel.SetText(message);
        }
    }
}