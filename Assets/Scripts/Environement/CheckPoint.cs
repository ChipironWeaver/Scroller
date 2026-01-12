using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public bool isActive = true;
    private Vector3 respawnPos;

    void Start()
    {
        respawnPos = GetComponent<Transform>().position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" || isActive)
        {
            if (player.GetComponent<DeathRespawn>().respawnPosition != respawnPos)
            {
                player.GetComponent<DeathRespawn>().respawnPosition = respawnPos;
                //play animation
            }
        }
    }
}
