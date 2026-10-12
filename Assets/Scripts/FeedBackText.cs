using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]

public class FeedBackText : MonoBehaviour
{
    TextMeshPro myText;
    [SerializeField] Vector3 startScale = Vector3.one;
    [SerializeField] Vector3 EnlargedScale;
    [SerializeField] float EnlargedAmount;

    public void Initialize(string aText, float EnlargeAmount = 2)
    {
        startScale = transform.localScale;
        EnlargedScale = startScale * (this.EnlargedAmount = EnlargeAmount);

        myText = GetComponent<TextMeshPro>();
        Debug.Log("Test: " + (myText != null));
        myText.text = aText;

        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(startScale, EnlargedScale, t);
            yield return null;
        }

        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(EnlargedScale, Vector3.zero, t);
            yield return null;
        }
    }
}
