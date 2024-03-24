using UnityEngine;
using UnityEngine.UI;

public class CollisionScreen : MonoBehaviour
{
    [SerializeField] private SimpleTimer _timer;
    [SerializeField] private CollisionCounter _collisionCounter;
    [SerializeField] private Button _resetButton;

    private void Awake()
    {
        _resetButton.onClick.AddListener(Restart);
    }

    private void Start()
    {
        _timer.Run();
    }

    private void Restart()
    {
        _timer.ResetToZero();
        _collisionCounter.ResetToZero();
    }
}
