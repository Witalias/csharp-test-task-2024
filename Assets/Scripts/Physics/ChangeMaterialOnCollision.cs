using UnityEngine;

public class ChangeMaterialOnCollision : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private MeshRenderer _mesh;

    public void Change()
    {
        _mesh.material = _material;
        Destroy(this);
    }
}
