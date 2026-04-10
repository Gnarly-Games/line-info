using Gnarly.LineInfo;
using UnityEngine;

namespace Gnarly.LineInfo
{
    [DefaultExecutionOrder(-100)]
    public class LineInfoManager : MonoBehaviour
    {
        private static LineInfoManager _instance;

        [Header("References")]
        public LineInfoItem prefab;
        public Transform parent;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        public static void Show(string message, float duration = 1f)
        {
            if (_instance == null)
            {
                Debug.LogWarning("LineInfoManager.Show called before a LineInfoManager instance was loaded.");
                return;
            }

            if (_instance.prefab == null)
            {
                Debug.LogWarning("LineInfoManager is missing its LineInfoItem prefab reference.", _instance);
                return;
            }

            var parentTransform = _instance.parent != null ? _instance.parent : _instance.transform;
            var info = Instantiate(_instance.prefab, parentTransform);
            info.Init(message, duration);
        }
    }
}
