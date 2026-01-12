using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 respawnPos;
    
    void Start()
    {
        respawnPos = GetComponent<Transform>().position;
    }

    void onTriggerEnter2D(Collision collision)
    {
        Debug.Log("BOOO");
        if (player.GetComponent<DeathRespawn>().respawnPosition != respawnPos)
        {
            player.GetComponent<DeathRespawn>().respawnPosition =respawnPos;
            //play animation
        }
    }
}
