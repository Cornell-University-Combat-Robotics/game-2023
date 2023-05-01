using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    public Dictionary<int, bool> IsAlive;

    private void Awake() {
        IsAlive = new Dictionary<int, bool>();
    }

    IEnumerator _backToMenu()
    {
        yield return new WaitForSeconds(5f);
        GameManager.Instance.BackToMenu();
    }

    public void RegisterPlayerAlive(int playerID)
    {
        IsAlive[playerID] = true;
    }

    public void RegisterPlayerDead(int playerID)
    {
        IsAlive[playerID] = false;
        Debug.Log(IsAlive);
        // check to see if all but one are dead
        int lastLivingID = -1;
        int numAlive = 0;
        foreach (var state in IsAlive)
        {
            if (state.Value)
            {
                lastLivingID = state.Key;
                numAlive += 1;
            }
        }
        if (numAlive <= 1)
        {
      // show win screen
      GameObject.Find("WinScreen").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -140);
            GameObject.Find("WinScreen").GetComponent<WinScreen>().UpdateWinner(lastLivingID);
            // start back to menu sequence
            StartCoroutine(_backToMenu());
        }
    }
}
