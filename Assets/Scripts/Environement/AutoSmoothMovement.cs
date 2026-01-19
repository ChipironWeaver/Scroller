using System.Collections;
using UnityEngine;

public class AutoSmoothMovement : MonoBehaviour
{
    [SerializeField] Vector3 baseOffSet = Vector3.zero;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float smoothTime = 0f;
    [SerializeField] private bool isActive = true;
    private Vector3 basePosition = Vector3.zero;
    private Vector3 offSet = Vector3.zero;
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
        basePosition = _transform.position;
        StartCoroutine(Loop());
        

        IEnumerator Loop()
        {
            while (isActive)
            {
                offSet = baseOffSet;
                yield return new WaitForSeconds(speed);
                offSet = Vector3.zero;
                yield return new WaitForSeconds(speed);
            }
        }
    }
}
