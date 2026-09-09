using UnityEngine;

public class  Camera_Player_Follow_Script : MonoBehaviour 
{
    [SerializeField] Transform objectToFollow;
    [SerializeField] float followSpeed;  // This value should be equal to the player's max possible speed. In order to prevent the player to get outside of the camera view.

    void Start()
    {
        // Make sure the camera has *some* speed to follow whatever object it is following

        if (followSpeed == 0)
        {
            followSpeed = objectToFollow.GetComponent<PlayerMovement>().moveSpeed;
        }
        else
        {
            Debug.Log("Not supposed to happen");
        }
    }

    void Update()
    {
        // calculate the distance between this object and the target object
        // and move a portion of that distance each frame:

        Vector3 delta = objectToFollow.position - transform.position;
        delta.z = 0; // make sure the GameObject this script is attached to doesn't (try to) get closer on the Z-Axis

        transform.position += delta * Time.deltaTime * (followSpeed * 0.33f);
                                                                    /* ↑  Smoothen the cameras movement to make it less 'jerky'*/
    }
}
