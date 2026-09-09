using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject Player;

    [SerializeField] float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (moveSpeed == 0)
        {
            moveSpeed = 3; // Simply a base movement Speed unless any other is provided Via the SerializeField
        }
    }

    // Update is called once per frame
    void Update()
    {
        // calculate the distance between this object (The enemy) and the target object (The Player)
        // and move a portion of that distance each frame:

        Vector3 delta = Player.transform.position - transform.position;

        delta.z = 0; // make sure the GameObject this script is attached to doesn't (try to) get closer on the Z-Axis

        transform.position += delta * Time.deltaTime * (moveSpeed * 0.9f);
                                                                  /* ↑  makey the enemy slightly slower than the player in order to allow them to move away*/
    }
}
