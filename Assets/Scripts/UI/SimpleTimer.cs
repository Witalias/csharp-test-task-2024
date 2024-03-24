using System.Collections;
using TMPro;
using UnityEngine;

public class SimpleTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Coroutine _timerCoroutine;
    private int _currentSecond;

    public void Run()
    {
        _timerCoroutine ??= StartCoroutine(Process());
    }

    public void Stop()
    {
        if (_timerCoroutine != null)
            StopCoroutine(_timerCoroutine);
        _timerCoroutine = null;
    }

    public void ResetToZero()
    {
        _currentSecond = 0;
        UpdateText(0);
    }

    private IEnumerator Process()
    {
        var waitSecond = new WaitForSeconds(1.0f);
        while (true)
        {
            UpdateText(++_currentSecond);
            yield return waitSecond;
        }
    }

    private void UpdateText(int seconds)
    {
        _text.text = $"Времени прошло: {seconds}";
    }
}
