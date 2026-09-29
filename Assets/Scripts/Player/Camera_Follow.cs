using UnityEngine;

public class Camera_Follow : MonoBehaviour 
{
    [SerializeField] Transform objectToFollow; // aka The player
    [SerializeField] float followSpeed;  // This value should be equal to the player's max possible speed. In order to prevent the player to get outside of the camera view.
    [SerializeField] float minX, maxX, minY, maxY;

    private void Start()
    {
        if (objectToFollow.CompareTag("Player"))
        {
            followSpeed = GameManager.singleton.Player_MoveSpeed / 2;
        }

        // otherwise followspeed is set in the inspector
    }

    void LateUpdate()
    {
        if (objectToFollow == isActiveAndEnabled)
        {
            // calculate the distance between this object and the target object
            Vector3 delta = objectToFollow.position - transform.position;

            // make sure the GameObject this script is attached to doesn't (try to) get closer on the Z-Axis (since this is a 2D game)
            delta.z = 0;

            if (Vector2.Distance(new Vector2(delta.x, delta.y), new Vector2(transform.position.x, transform.position.y)) > 100)
            {
                // if the distance (somehow) goes beyon a certain point just set the position to the object we are following.
                transform.position = new Vector3(objectToFollow.position.x, objectToFollow.position.y, -10);
                return;
            } 
            else
            {
                // Move by the calculated delta distance, per second, amplified by the desired follow speed
                transform.position += (Time.deltaTime * followSpeed) * delta;
            }

            // out of bounds check and handeling
            if (transform.position.x < minX)
            {
                transform.position = new Vector3(minX, transform.position.y, -10);
            }
            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y, -10);
            }

            if (transform.position.y < minY)
            {
                transform.position = new Vector3(transform.position.x, minY, -10);
            }
            if (transform.position.y > maxY)
            {
                transform.position = new Vector3(transform.position.x, maxY, -10);
            }
        }
    }
}
