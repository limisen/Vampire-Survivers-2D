using UnityEngine;

public class EnemyMovement_Type_2 : MonoBehaviour
{
    [SerializeField] float minDistance;
    float Distance;
    float moveSpeed;
    [SerializeField] private Animator AnimationController;
    GameObject player;

    [SerializeField] GameObject SyringePrefab;

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

            // Move towards ONLY if it's farther away than minDistance to the target (aka the player)
            Distance = Vector3.Distance(player.transform.position, transform.position);
            if (Distance > minDistance)
            {
                transform.position += (Time.deltaTime * moveSpeed) * delta;            
            }
            else if (Distance < minDistance)
            {
                transform.position += transform.position - player.transform.position;
            }

            //if (/*Enemy is close enough*/)
            //{
            //    // throw a syringe
            //    Instantiate(SyringePrefab, transform.position, Quaternion.identity);
            //}

            // Animator Variables reset
            AnimationController.SetBool("Idle", false);
            AnimationController.SetBool("MovingRight", false);
            AnimationController.SetBool("MovingLeft", false);
            AnimationController.SetBool("MovingUp", false);
            AnimationController.SetBool("MovingDown", false);

            // Depending on the direction's magnitude decide if we are moving more on the X- or Y-Axis then set the respective animation Bool to true
            if (Mathf.Abs(delta.x) > (Mathf.Abs(delta.y)))
            {
                if (delta.x < 0)
                {
                    AnimationController.SetBool("MovingLeft", true);
                }
                else if (delta.x > 0)
                {
                    AnimationController.SetBool("MovingRight", true);
                }
            }
            else if (Mathf.Abs(delta.x) < (Mathf.Abs(delta.y)))
            {
                if (delta.y < 0)
                {
                    AnimationController.SetBool("MovingDown", true);
                }
                else if (delta.y > 0)
                {
                    AnimationController.SetBool("MovingUp", true);
                }
            }
            else
            {
                AnimationController.SetBool("Idle", true);
            }
        }
    }
}
