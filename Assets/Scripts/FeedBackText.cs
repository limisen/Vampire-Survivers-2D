using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]

public class FeedBackText : MonoBehaviour
{
    TextMeshPro myText;
    [SerializeField] Vector3 startScale;
    [SerializeField] Vector3 EnlargedScale;
    [SerializeField] float EnlargedAmount;

    public void Initialize(string aText, float EnlargeAmount = 1.5f)
    {
        startScale = transform.localScale;

        if (EnlargeAmount != 1.5f)
        {
            EnlargedScale = startScale * EnlargeAmount;
        }
        else
        {
            EnlargedScale = startScale * this.EnlargedAmount;
        }


        myText = GetComponent<TextMeshPro>();
        Debug.Log("Test: " + (myText != null));
        myText.text = aText;

        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(Vector3.zero, startScale, t);
            yield return null;
        }

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
        Destroy(gameObject);
    }
}
