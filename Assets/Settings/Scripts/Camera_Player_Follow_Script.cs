using UnityEngine;

public class Camera_Player_Follow_Script : MonoBehaviour
{
    [SerializeField] Transform objectToFollow;
    [SerializeField] float followSpeed = 4;  // This value should be equal to the player's max possible speed. In order to prevent the player to get outside of the camera view.


    private void Update()
    {
        // calculate the distance between this object and the target object
        // and move a small portion of that distance each frame:

        Vector3 delta = objectToFollow.position - transform.position;
        delta.z = 0; // make sure the GameObject this script is attached to doesn't (try to) get closer or pass through the Object it is following
        transform.position += delta * Time.deltaTime * followSpeed;
    }
}
