using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public bool isActive = true;
    [SerializeField] private MonoBehaviour script;
    private Vector2 respawnPos;
    private PlayerHealthController _playerHealthController;

    void Start()
    {
        respawnPos = GetComponent<Transform>().position;
        _playerHealthController = player.GetComponent<PlayerHealthController>();
    }

    void Update()
    {
        if (script.enabled && _playerHealthController.respawnPosition != respawnPos )
        {
            if (script != null)
            {
                script.enabled = false;
            }
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (_playerHealthController.respawnPosition != respawnPos)
        {
            if (collision.gameObject.tag == "Player" || isActive) 
            {
                _playerHealthController.respawnPosition = new Vector3(respawnPos.x, respawnPos.y, 0);
                //play animation
                if (script != null)
                {
                    script.enabled = true;
                }
            }
        }
    }
}
