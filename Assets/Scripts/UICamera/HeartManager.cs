using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class HeartManager : MonoBehaviour
{
    [SerializeField] [Range(0, 40)] private int maxHealth; //1 visual heart is considered as 2 HP
    [SerializeField] [Range(0, 40)] int health;
    [SerializeField] [Range(0, 5)] private int tempHealth; //Temp Health is WIP
    [SerializeField] [Range(1, 10)] int heartsPerColumn; //Counts the visual hearts
    [SerializeField] private Vector3 offSet;
    
    [SerializeField] private List<Sprite> hearts;
    //6 images required in this order:
    //0 = Full Heart
    //1 = Half Full Heart
    //2 = Empty Heart
    //3 = Half Empty Heart
    //4 = Half Full Heart with empty
    //5 = Temp Heart
    [SerializeField] public GameObject heartPrefab;
    private Image _image;
    private List<GameObject> _hearts = new();
    private Vector3 healthMemory;
    
    void Update()
    {
        if (new Vector3(health, maxHealth, tempHealth) != healthMemory)
        {
            while (_hearts.Count < (float)maxHealth / 2)
            {
                GameObject _temp = CreateHeart(_hearts.Count);
                _hearts.Add(_temp);
            }
            
            
            
        }
    }

    GameObject CreateHeart( int _position)
    {
        GameObject heart = Instantiate<GameObject>(heartPrefab);
        heart.transform.SetParent(gameObject.transform,false);
        heart.GetComponent<RectTransform>().localPosition = new Vector3(offSet.x * (_position % heartsPerColumn + 1),offSet.y*(_position/ heartsPerColumn));
        heart.name = "Heart " + _position.ToString();
        return heart;
    }
}
