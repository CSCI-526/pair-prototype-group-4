using UnityEngine;
using UnityEngine.UI;

public class FlagManager : MonoBehaviour
{
    public static FlagManager instance;
    private int flagCount = 0;

    public Text flagText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnDestroy()
    {
        instance = null;
    }

    public void AddFlag()
    {
        flagCount++;
        flagText.text = flagCount.ToString();
        Debug.Log("Total Flags Collected: " + flagCount);
    }
}
