using System;
using UnityEngine;

public class Structure : MonoBehaviour
{
    [SerializeField] private float _repulsiveForce;
    [SerializeField] private float _maxVelocityMagnitude;

    public static event Action OnCollided;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<ChangeMaterialOnCollision>(out var material))
            material.Change();

        // Чтобы событие OnCollided было вызвано только с одной стороны столкновения
        if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
            OnCollided?.Invoke();

        Repulse(collision);
    }

    private void Repulse(Collision other)
    {
        if (other.rigidbody == null)
            return;

        var velocity = other.relativeVelocity.magnitude > _maxVelocityMagnitude
            ? other.relativeVelocity.normalized * _maxVelocityMagnitude
            : other.relativeVelocity;
        other.rigidbody.AddForce(velocity * _repulsiveForce);
    }
}
