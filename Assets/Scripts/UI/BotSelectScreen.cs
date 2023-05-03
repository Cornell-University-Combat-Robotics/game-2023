using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotSelectScreen : MonoBehaviour
{
    public Text CountdownText;
    public Text CurrentStageText;

    public int ReadyPlayerCount;

    private bool isCountingDown = false;
    private float countdown = 0f;

    private void Awake() {
        // disable countdown text until time to start
        CountdownText.gameObject.SetActive(false);
        CurrentStageText.text = GameManager.Instance.CurrentStage.ToString();
    }

    public void StartCountdown()
    {
        CountdownText.gameObject.SetActive(true);
        isCountingDown = true;
        countdown = 3f;
    }

    public void StopCountdown()
    {
        CountdownText.gameObject.SetActive(false);
        isCountingDown = false;
    }

    private void Update() {
    // check to see if we can start counting down
    if (!isCountingDown && GameManager.Instance.PlayerData.Count == ReadyPlayerCount && ReadyPlayerCount > 1)
            StartCountdown();
        // check to see if we should stop countdown
        if (isCountingDown && GameManager.Instance.PlayerData.Count != ReadyPlayerCount)
            StopCountdown();
        // tick countdown
        if (isCountingDown)
        {
            countdown -= Time.deltaTime;
            CountdownText.text = "Starting In " + countdown.ToString().Substring(0, 3);
            if (countdown < 0)
            {
                // start game
                GameManager.Instance.StartGame();
            }
        }
    }
}
