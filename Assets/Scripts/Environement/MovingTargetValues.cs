using UnityEngine;
public class MovingTargetValues : MonoBehaviour
{
    [SerializeField] Transform targetA;
    [SerializeField] Transform targetB;
    [SerializeField] float speed;
    [SerializeField] float waitTime;
    float _currentTime;
    private Animation _animation;

    private void Start()
    {
        AnimationClip clip = new  AnimationClip();
        _animation = GetComponent<Animation>();
        _animation.clip = clip;
        Keyframe[] keys = new Keyframe[4];
        keys[0] = new Keyframe(_currentTime,targetA.position.x); //move to target A
        _currentTime += speed; //move time
        keys[1] = new Keyframe(_currentTime,targetA.position.x); //target A
        _currentTime += waitTime; //wait time
        keys[2] = new Keyframe(_currentTime,targetB.position.x); //move to target B
        _currentTime += speed; //move time
        keys[3] = new Keyframe(_currentTime,targetB.position.x); //target B
        clip.SetCurve("Platform", typeof(Transform), "position.x", new AnimationCurve(keys));
        keys[0] = new Keyframe(_currentTime,targetA.position.y); //move to target A
        _currentTime += speed; //move time
        keys[1] = new Keyframe(_currentTime,targetA.position.y); //target A
        _currentTime += waitTime; //wait time
        keys[2] = new Keyframe(_currentTime,targetB.position.y); //move to target B
        _currentTime += speed; //move time
        keys[3] = new Keyframe(_currentTime,targetB.position.y); //target B
        clip.SetCurve("Platform", typeof(Transform), "position.y", new AnimationCurve(keys));
        clip.legacy = true;
        _animation.AddClip(clip, "PlatformAnimation");
        _animation.Play("PlatformAnimation");
    }
}
