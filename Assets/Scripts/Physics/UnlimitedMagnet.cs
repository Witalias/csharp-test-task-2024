using UnityEngine;

public class UnlimitedMagnet : MonoBehaviour
{
    [SerializeField] private float _gravityForce;
    [SerializeField] private float _stoppingDistance;
    [SerializeField, Range(0.0f, 1.0f)] private float _stoppingSpeed;
    [SerializeField] private Transform _gravityCenter;
    [SerializeField] private Rigidbody[] _gravitateObjects;

    private void FixedUpdate()
    {
        Gravitate();
    }

    private void Gravitate()
    {
        foreach (var obj in _gravitateObjects)
        {
            var direction = _gravityCenter.position - obj.position;
            if (direction.magnitude < _stoppingDistance)
                SlowDown(obj);
            else
                SpeedUp(obj, direction);
        }
    }

    private void SpeedUp(Rigidbody rigidbody, Vector3 direction)
    {
        rigidbody.AddForce(_gravityForce * Time.fixedDeltaTime * direction.normalized, ForceMode.Impulse);
    }

    private void SlowDown(Rigidbody rigidbody)
    {
        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, _stoppingSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_gravityCenter.position, _stoppingDistance);
    }
}
