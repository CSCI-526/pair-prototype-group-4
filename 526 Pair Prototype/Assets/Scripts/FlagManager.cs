using UnityEngine;

public class FlagManager : MonoBehaviour
{
    public static FlagManager instance;
    private int flagCount = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddFlag()
    {
        flagCount++;
        Debug.Log("Total Flags Collected: " + flagCount);
    }
}
