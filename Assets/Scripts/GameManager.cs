using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    [SerializeField] public bool gamePaused = true;

    private void Awake()
    {
        if (singleton != null)
        {
            Destroy(this);
            return;
        }

        singleton = this;
    }
}