using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
public class MovingTargetValues : MonoBehaviour
{
    [SerializeField] Transform targetA;
    [SerializeField] Transform targetB;
    [SerializeField] float Speed;
    [SerializeField] float waitTime;
    float currentTime;
    private Animator animator;
    private AnimationClip clip;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Keyframe[] keys = new Keyframe[4];
        keys[0] = new Keyframe(0f,0f);
        keys[1] = new Keyframe(1f,0f);
        keys[2] = new Keyframe(2f,0f);
        keys[3] = new Keyframe(3f,0f);
        //clip.SetCurve("",typeof(Transform), "localPosition", keys);
    }
}
