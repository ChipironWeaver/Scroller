using System.Collections;
using UnityEngine;

public class AutoSmoothMovement : MonoBehaviour
{
    [SerializeField] Vector2 baseOffSet = new Vector2(0f, 0f);
    [SerializeField] private float speed = 3f;
    [SerializeField] private float smoothTime = 0f;
    [SerializeField] private bool isActive = true;
    private Vector2 basePosition = Vector2.zero;
    private Vector2 offSet = Vector2.zero;
    private Transform _transform;
    private Vector3 _velocity = Vector3.zero;

    void FixedUpdate()
    {
        if (isActive)
        {
            transform.position = Vector3.SmoothDamp(transform.position, basePosition + offSet, ref _velocity, smoothTime);
        }
    }

    void Start()
    {
        _transform = GetComponent<Transform>();
        basePosition = new Vector2(_transform.position.x, _transform.position.y);
        StartCoroutine(Loop());

        IEnumerator Loop()
        {
            while (isActive)
            {
                offSet = baseOffSet;
                yield return new WaitForSeconds(speed);
                offSet = Vector2.zero;
                yield return new WaitForSeconds(speed);
            }
        }
    }
}
