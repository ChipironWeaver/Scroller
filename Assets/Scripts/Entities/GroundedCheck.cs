using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    
    public bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize,0 ,-transform.up , castDistance, groundLayer))
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }
}
