using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] public InputAction moveAction;
    [SerializeField] public InputAction UI_Action;
    private float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = playerData.moveSpeed;
        moveAction.Enable();
        UI_Action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = playerData.moveSpeed;

        // Old input system KeyCode:
        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.position += new Vector3(0, moveSpeed * 1, 0) * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.position += new Vector3(0, moveSpeed * -1, 0) * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.position += new Vector3(moveSpeed * -1, 0, 0) * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.position += new Vector3(moveSpeed * 1, 0, 0) * Time.deltaTime;
        //}

        // Old input system GetAxis:
        //if (playerData.GetComponent<PlayerData>().gameMenu.gamePaused == false)
        //{
        //    transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized * Time.deltaTime * moveSpeed;
        //}
        // New input sytem movement specifically:
        if (gameObject.GetComponentInParent<PlayerData>().gameMenu.gamePaused == false)
        {
            Vector2 moveDirection = moveAction.ReadValue<Vector2>(); // Get the direction to move in.
            transform.position += new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed * Time.deltaTime; // Move the player
        }
    }
}
