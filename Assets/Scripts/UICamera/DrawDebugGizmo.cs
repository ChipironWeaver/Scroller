using UnityEngine;

public class DrawDebugGizmo : MonoBehaviour
{
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private Color color;
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position-transform.up, boxSize);
    }
}
