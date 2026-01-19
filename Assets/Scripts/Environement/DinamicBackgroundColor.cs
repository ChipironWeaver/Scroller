using UnityEngine;

public class DinamicBackgroundColor : MonoBehaviour
{
    [SerializeField] float transitionTime = 5f;
    [SerializeField] Color firstColor = Color.white;
    [SerializeField] Color secondColor = Color.black;
    [SerializeField] Color currentColor;
    private float transitionCurrentTime = 0f;
    void Update()
    {
        transitionCurrentTime = Mathf.PingPong(Time.unscaledTime,transitionTime);
        //currentColor = colorTransition(firstColor, secondColor,transitionCurrentTime,transitionTime);
        currentColor = Color.Lerp(firstColor, secondColor, transitionCurrentTime/transitionTime);
        Camera.main.backgroundColor = currentColor;
      
    }
}
