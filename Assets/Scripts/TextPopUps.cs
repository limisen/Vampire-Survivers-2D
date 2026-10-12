using UnityEngine;

public class TextPopUps : MonoBehaviour
{
    public static void SpawnText(FeedBackText TextPrefab, string Text, Vector3 position, float EnlargeAmount = 1.5f)
    {
        FeedBackText text = Instantiate(TextPrefab, position, Quaternion.identity);
        text.GetComponent<FeedBackText>().Initialize(Text, EnlargeAmount);
    }
}
