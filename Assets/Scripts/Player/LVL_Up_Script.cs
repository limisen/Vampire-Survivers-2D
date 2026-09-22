using TMPro;
using UnityEngine;

public class LVL_Up_Script : MonoBehaviour
{


    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
            

        }
    }
}
