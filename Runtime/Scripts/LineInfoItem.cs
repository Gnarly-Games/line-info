using System.Collections;
using TMPro;
using UnityEngine;

namespace Gnarly.LineInfo
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LineInfoItem : MonoBehaviour
    {
        public TMP_Text messageLabel;

        private CanvasGroup _canvasGroup;
        private Coroutine _lifecycleRoutine;

        public void Init(string message, float duration)
        {
            if (_canvasGroup == null)
            {
                _canvasGroup = GetComponent<CanvasGroup>();
            }

            if (messageLabel == null)
            {
                Debug.LogWarning("LineInfoItem is missing a message label reference.", this);
                return;
            }

            if (_lifecycleRoutine != null)
            {
                StopCoroutine(_lifecycleRoutine);
            }

            messageLabel.SetText(message);
            _canvasGroup.alpha = 1f;
            transform.localScale = Vector3.one * 2f;
            _lifecycleRoutine = StartCoroutine(PlayLifecycle(Mathf.Max(0f, duration)));
        }

        private IEnumerator PlayLifecycle(float duration)
        {
            yield return AnimateScale(2f, 1f, 0.2f);

            if (duration > 0f)
            {
                yield return new WaitForSecondsRealtime(duration);
            }

            yield return AnimateAlpha(1f, 0f, 0.2f);
            Destroy(gameObject);
        }

        private IEnumerator AnimateScale(float from, float to, float duration)
        {
            var elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.unscaledDeltaTime;
                var t = Mathf.Clamp01(elapsed / duration);
                var eased = EaseOutBack(t);
                transform.localScale = Vector3.one * Mathf.LerpUnclamped(from, to, eased);
                yield return null;
            }

            transform.localScale = Vector3.one * to;
        }

        private IEnumerator AnimateAlpha(float from, float to, float duration)
        {
            var elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.unscaledDeltaTime;
                var t = Mathf.Clamp01(elapsed / duration);
                _canvasGroup.alpha = Mathf.Lerp(from, to, t);
                yield return null;
            }

            _canvasGroup.alpha = to;
        }

        private static float EaseOutBack(float t)
        {
            const float overshoot = 1.70158f;
            var shifted = t - 1f;
            return 1f + (overshoot + 1f) * shifted * shifted * shifted + overshoot * shifted * shifted;
        }
    }
}
