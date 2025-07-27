using UnityEngine;

public class NameStorer : MonoBehaviour
{

    public string playerName;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetPlayerName(string newName)
    {
        playerName = newName;
    }
}
