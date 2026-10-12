using UnityEngine;

public class AuraVisuals : MonoBehaviour
{
    void Update()
    {
        float radius = GameManager.singleton.Aura_Radius;

        radius *= 1.15f;

        transform.localScale = new Vector3(radius, radius, 0);
    }
}
