using UnityEngine;

public class Camera_Follow : MonoBehaviour 
{
    [SerializeField] Transform objectToFollow; // aka The player
    [SerializeField] float followSpeed;  // This value should be equal to the player's max possible speed. In order to prevent the player to get outside of the camera view.

    private void Start()
    {
        if (objectToFollow.CompareTag("Player"))
        {
            followSpeed = objectToFollow.GetComponent<PlayerData>().moveSpeed / 2;
        }

        // otherwise followspeed is set in the inspector
    }

    void Update()
    {
        if (objectToFollow == isActiveAndEnabled)
        {
            // calculate the distance between this object and the target object
            Vector3 delta = objectToFollow.position - transform.position;

            // make sure the GameObject this script is attached to doesn't (try to) get closer on the Z-Axis (since this is a 2D game)
            delta.z = 0;

            // Move by the calculated delta distance, per second, amplified by the desired follow speed
            transform.position += (Time.deltaTime * followSpeed) * delta;
        }
    }
}
