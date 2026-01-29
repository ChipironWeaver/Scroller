using UnityEngine;
using Image = UnityEngine.UI.Image;

public class UISetColorAsBackgroud : MonoBehaviour
{
    [SerializeField][Range(0.0f, 1.0f)] private float tintPourcentage;
    [SerializeField] private Camera _camera;
    void Update()
    {
        GetComponent<Image>().color = Color.Lerp(_camera.backgroundColor, Color.white, tintPourcentage);
    }
}
