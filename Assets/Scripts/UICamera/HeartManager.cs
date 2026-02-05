using System;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using System.Collections.Generic;

public class HeartManager : MonoBehaviour
{
    [Header("Health Settings")]
    [Range(0, 40)] public int maxHealth; //1 visual heart is considered as 2 HP
    [Range(0, 40)] public int health;
    [Header("Render Settings")]
    [SerializeField] [Range(1, 10)] private int _heartsPerColumn; //Counts the visual hearts
    [SerializeField] private Vector3 _offSet;
    [Header("Sprite")]
    [SerializeField] private List<Sprite> _hearts;
    //0 = Full Heart
    //1 = Half Full Heart
    //2 = Empty Heart
    //3 = Half Empty Heart
    //4 = Half Full Heart with empty
    [SerializeField] private GameObject _heartPrefab;
    private List<GameObject> _heartGameObjects = new();
    private Vector3 _healthMemory;
    
    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
            Debug.LogWarning("Imposible Health Value in: " + gameObject.name);
        }
        if (new Vector3(health, maxHealth) != _healthMemory)
        {
            RenderHearts();
            _healthMemory = (new Vector3(health, maxHealth));
        }
    }

    GameObject CreateHeart(int _position)
    {
        GameObject heart = Instantiate<GameObject>(_heartPrefab);
        heart.transform.SetParent(gameObject.transform,false);
        heart.GetComponent<RectTransform>().localPosition = new Vector3(_offSet.x * (_position % _heartsPerColumn + 1),_offSet.y*(_position/ _heartsPerColumn));
        heart.name = "Heart " + _position.ToString();
        return heart;
    }

    void RenderHearts()
    {
        AddHearts();
        for (int i = 0; i < _heartGameObjects.Count; i ++)
        {
            if (i < maxHealth / 2)
            {
                _heartGameObjects[i].SetActive(true);
                if (i < health / 2)
                {
                    _heartGameObjects[i].GetComponent<Image>().sprite = _hearts[0];
                }
                else if (i < (float)health / 2)
                {
                    _heartGameObjects[i].GetComponent<Image>().sprite = _hearts[3];
                }
                else
                {
                    _heartGameObjects[i].GetComponent<Image>().sprite = _hearts[2];
                }
            }
            
            else if (i < (float)maxHealth / 2)
            {
                _heartGameObjects[i].SetActive(true);
                if (i < (float)health / 2)
                {
                    _heartGameObjects[i].GetComponent<Image>().sprite = _hearts[1];
                }
                else
                {
                    _heartGameObjects[i].GetComponent<Image>().sprite = _hearts[4];
                }
            }
            else
            {
                _heartGameObjects[i].SetActive(false);
            }
        }
    }

    private void AddHearts()
    {
        while (_heartGameObjects.Count < (float)maxHealth / 2 )
        {
            _heartGameObjects.Add(CreateHeart(_heartGameObjects.Count));
        }
    }

    public void UpdateHealth(int _health, int _maxHealth)
    {
        health = _health;
        maxHealth = _maxHealth;
    }
}
