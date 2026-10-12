using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float moveSpeed;
    [SerializeField] private Animator AnimationController;
    GameObject player;

    private void Awake()
    {
        if (moveSpeed == 0) { moveSpeed = GetComponent<EnemyData>().moveSpeed; }
        
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }


    void LateUpdate()
    {
        if (GameManager.singleton.gamePaused == false && isActiveAndEnabled)
        {
            // calculate the distance between this object (The enemy) and the target object (The Player)
            Vector3 delta = player.transform.position - transform.position;

            // make sure not to move closer on the Z-Axis
            delta.z = 0;

            // Make it so the direaction/point we are moving to doesnt change the speed of the movement, based on the distance.
            delta.Normalize();

            // Calculate the amount to rotate in order to face the target, then convert it from Radiants to Degrees
            float angle_to_rotate = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

            // Now set the position and then rotate so we are facing the target (aka the player)
            transform.SetPositionAndRotation((transform.position += (Time.deltaTime * moveSpeed) * delta), Quaternion.AngleAxis(angle_to_rotate, Vector3.forward));

            // Animator Variables reset
            AnimationController.SetBool("Idle", false);
            AnimationController.SetBool("MovingRight", false);
            AnimationController.SetBool("MovingLeft", false);
            AnimationController.SetBool("MovingUp", false);
            AnimationController.SetBool("MovingDown", false);

            // Depending on the direction we are moving set the respective animation Bool to true
            if (delta.x < 0)
            {
                AnimationController.SetBool("MovingLeft", true);
            }
            else if (delta.x > 0)
            {
                AnimationController.SetBool("MovingRight", true);
            }
            else if (delta.y < 0)
            {
                AnimationController.SetBool("MovingDown", true);
            }
            else if (delta.y > 0)
            {
                AnimationController.SetBool("MovingUp", true);
            }
            else
            {
                AnimationController.SetBool("Idle", true);
            }
        }
    }
}
