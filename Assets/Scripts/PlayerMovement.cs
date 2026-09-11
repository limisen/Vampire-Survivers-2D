using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public readonly PlayerData playerData;
    [SerializeField] GameObject playerData;
    [SerializeField] public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = playerData.GetComponent<PlayerData>().moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Old input system
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

        // New input system
        if (playerData.GetComponent<PlayerData>().gameMenu.gamePaused == false)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed, 0) * Time.deltaTime;
        }
    }
}
