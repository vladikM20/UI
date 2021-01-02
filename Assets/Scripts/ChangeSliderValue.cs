using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSliderValue : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _duration;

    private Coroutine _changeValue;

    public void ChangeValue(int value)
    {
        if (_changeValue != null)
            StopCoroutine(_changeValue);

        _changeValue = StartCoroutine(SmoothChangeValue(_slider.value, _slider.value + value, _duration));
    }

    private IEnumerator SmoothChangeValue(float startValue, float endValue, float duration)
    {
        float elapsed = 0;

        while(_slider.value != endValue)
        {
            _slider.value = Mathf.Lerp(startValue, endValue, elapsed / duration);
            elapsed += Time.deltaTime;

            yield return null;
        }
    }
}
