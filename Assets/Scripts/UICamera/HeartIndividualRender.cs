using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartIndividualRender : MonoBehaviour
{
    Image _image;
    public int state;
    [SerializeField] private List<Sprite> hearts;

    void Start()
    {
        _image = gameObject.GetComponent<Image>();
    }
    void Update()
    {
        if (state <= hearts.Count && state > -1)
        {
            _image.sprite = hearts[state];
        }
        else
        {
            Debug.Log("Unknown state");
        }
    }
}
