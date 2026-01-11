using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class AutoMouvement : MonoBehaviour
{
    [SerializeField] Vector2 offSet = new Vector2(0f,0f);
    [SerializeField] private float speed = 10f;
    private Vector2 relativeOffSet = Vector2.zero;
    private Vector2 baseOffset = Vector2.zero;
    private Transform _transform;
    private int direction = 1;

    void Start()
    {
        _transform = GetComponent<Transform>();
        baseOffset = new Vector2(_transform.position.x, _transform.position.y);
    }
    void FixedUpdate()
    {
        if (direction != 0f)
        {
            relativeOffSet = new Vector2(relativeOffSet.x + (offSet.x /(speed*direction)), relativeOffSet.y + (offSet.y /(speed*direction)));
            if ((relativeOffSet.x >= offSet.x || relativeOffSet.y >= offSet.y) && direction > 0f)
            {
                relativeOffSet = offSet;
                direction = direction * -1;
            }
            else if ( relativeOffSet == Vector2.zero && direction < 0f)
            {
                relativeOffSet = Vector2.zero;
                direction = direction * -1;
            }
        }
        _transform.position = new Vector3(baseOffset.x + relativeOffSet.x, baseOffset.y + relativeOffSet.y);
    }
}
