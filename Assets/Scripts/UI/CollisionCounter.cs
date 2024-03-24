using System.Collections;
using TMPro;
using UnityEngine;

public class CollisionCounter : MonoBehaviour
{
    [SerializeField] private float _incrementDelay;
    [SerializeField] private TMP_Text _text;

    private int _count;

    private void OnEnable()
    {
        Structure.OnCollided += OnStructuresCollided;
    }

    private void OnDisable()
    {
        Structure.OnCollided -= OnStructuresCollided;
    }

    public void ResetToZero()
    {
        _count = 0;
        UpdateText(0);
    }

    private void OnStructuresCollided()
    {
        StopAllCoroutines();
        StartCoroutine(IncrementCount());
    }

    private IEnumerator IncrementCount()
    {
        yield return new WaitForSeconds(_incrementDelay);
        UpdateText(++_count);
    }

    private void UpdateText(int count)
    {
        _text.text = $"Столкновений: {count}";
    }
}
