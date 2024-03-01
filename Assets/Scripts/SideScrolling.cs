using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform player;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 cameraPos = transform.position;
        cameraPos.x = Mathf.Max(cameraPos.x, player.position.x);
        transform.position = cameraPos; 
    }
}
