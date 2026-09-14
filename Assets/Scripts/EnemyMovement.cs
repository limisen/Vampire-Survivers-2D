using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public GameObject Player;

    public EnemyData enemyData;
    [SerializeField] float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyData = GetComponent<EnemyData>();

        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isActiveAndEnabled && Player.GetComponentInParent<PlayerData>().gameMenu.gamePaused == false)
        {
            moveSpeed = enemyData.moveSpeed;


            // calculate the distance between this object (The enemy) and the target object (The Player)
            // and move a portion of that distance each frame:

            Vector3 delta = Player.transform.position - transform.position;

            delta.z = 0; // make sure the GameObject this script is attached to doesn't (try to) get closer on the Z-Axis

            delta.Normalize(); // Make it so the direaction/point we are moving to doesnt change the speed of the movement based on the distance

            transform.position += delta * moveSpeed * Time.deltaTime;
        }
    }
}
