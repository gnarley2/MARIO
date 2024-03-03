using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform playerTransform;
    private Player player;
    
    
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        player = playerTransform.GetComponent<Player>();
    }

    private void LateUpdate()
    {
        if (player.isDied) return;
        UpdateCamToPlayer();
    }

    void UpdateCamToPlayer()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Max(cameraPosition.x, playerTransform.position.x);
        transform.position = cameraPosition;
    }
}
