using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace NailInTheCoffin.Core
{
	public class LoadingScreen : MonoBehaviour
	{
        [SerializeField] private Image _blackScreen;
        [SerializeField] private float _fadeDuration = 1f;

        private Tween _tween;

        public IEnumerator ShowCoroutine(bool showProgress = true)
        {
            _tween = _blackScreen.DOFade(1f, _fadeDuration).Play();
            yield return _tween.WaitForCompletion();
        }
		
		public IEnumerator HideCoroutine()
		{
            _tween = _blackScreen.DOFade(0f, _fadeDuration);
            yield return _tween.WaitForCompletion();
        }
    }
}