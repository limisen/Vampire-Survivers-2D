using UnityEngine;

public class ChainLightning : MonoBehaviour
{
    int amount_to_chain = 1;

    private GameObject Player;
    private GameObject Enemy;

    private void Awake()
    {
        Player = FindAnyObjectByType<PlayerData>().gameObject;
        Enemy = GameObject.FindWithTag("Enemy");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy = 

        //Debug.Log("Enemey: " + Enemy.gameObject.name);
    }
}
