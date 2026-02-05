using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Image = UnityEngine.UI.Image;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string _scene;
    [SerializeField] private Color _transitionColor;
    [SerializeField] private float _transitionDuration;
    [SerializeField] private GameObject _loadingScreen;
    private GameObject _loadingScreenObject;
    private Image _image;
    

    public void LoadScene()
    {
        _loadingScreenObject = Instantiate(_loadingScreen);
        _image = _loadingScreenObject.transform.GetChild(0).gameObject.GetComponent<Image>();
        _image.color = new Color(_transitionColor.r, _transitionColor.g, _transitionColor.b, 0);
        StartCoroutine(LoadAnimation(_image));
    }

    private IEnumerator LoadAnimation(Image asset)
    {
        float _time = 0f;
        while (_time < _transitionDuration)
        {
            asset.color = new Color(_transitionColor.r, _transitionColor.g, _transitionColor.b, Mathf.PingPong(_time, _transitionDuration));
            yield return new WaitForEndOfFrame();
            _time += Time.deltaTime;
        }
        SceneManager.LoadSceneAsync(_scene);
        
    }
}
