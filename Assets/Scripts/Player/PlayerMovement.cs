using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float minX, maxX, minY, maxY; // Max Positional bounds (cant go beyond these values)

    private float moveSpeed;
    private void Awake()
    {
        moveSpeed = FindAnyObjectByType<GameManager>().Player_MoveSpeed;
    }

    private void Update()
    {
        //moveSpeed = GameManager.singleton.Player_MoveSpeed;
    }

    void LateUpdate()
    {
        // IF the game is unpaused and the player is active(andEnabled) then allow the player to move
        if (GameManager.singleton.gamePaused == false && isActiveAndEnabled)
        {
            // Move the Player
            transform.position += (moveSpeed * Time.deltaTime) * new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;


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
