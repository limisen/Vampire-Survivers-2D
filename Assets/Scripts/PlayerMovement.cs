using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float minX, maxX, minY, maxY; 

    float moveSpeed;
    private void Awake()
    {
        moveSpeed = gameObject.GetComponent<PlayerData>().moveSpeed;
    }

    void LateUpdate()
    {
        // IF the game is unpaused and the player is active(andEnabled) then allow the player to move
        if (GameManager.singleton.gamePaused == false && isActiveAndEnabled)
        {
            transform.position += (moveSpeed * Time.deltaTime) * new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;

            // out of bounds check and handeling
            if (transform.position.x < minX)
            {
                transform.position = new Vector3(minX , transform.position.y);
            }
            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y);
            }

            if (transform.position.y < minY)
            {
                transform.position = new Vector3(transform.position.x, minY);
            }
            if (transform.position.y > maxY)
            {
                transform.position = new Vector3(transform.position.x, maxY);
            }
        }
    }
}
