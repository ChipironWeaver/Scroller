using UnityEngine;

public class SetColorAsBackground : MonoBehaviour
{
    [SerializeField][Range(0.0f, 1.0f)] private float tintPourcentage;
    [SerializeField] private Camera _camera;
    void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.Lerp(_camera.backgroundColor, Color.white, tintPourcentage);
    }
}
