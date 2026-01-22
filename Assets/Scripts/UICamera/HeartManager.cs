using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartManager : MonoBehaviour
{
    [SerializeField] [Range(0, 40)] private int maxHealth; //1 visual heart is considered as 2 HP
    [SerializeField] [Range(0, 40)] int health;
    [SerializeField] [Range(0, 5)]private int tempHealth; //Temp Health is WIP
    [SerializeField] [Range(1, 10)] int heartsPerColumn; //Counts the visual hearts
    [SerializeField] private Vector2 offSet;
    
    [SerializeField] private List<Sprite> hearts;
    //6 images required in this order:
    //0 = Full Heart
    //1 = Half Full Heart
    //2 = Empty Heart
    //3 = Half Empty Heart
    //4 = Half Full Heart with empty
    //5 = Temp Heart
    
    private Image _image;
    private List<GameObject> _hearts;
    private Vector3 healthMemory;
    void Start()
    {
        _image = gameObject.GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (new Vector3(health, maxHealth, tempHealth) != healthMemory)
        {
            Debug.Log("boo");
            
            
            
            
            
            healthMemory = new Vector3(health, maxHealth, tempHealth);
        }
    }
}
