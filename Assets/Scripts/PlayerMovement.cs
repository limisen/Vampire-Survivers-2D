using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
        }
    }
}
