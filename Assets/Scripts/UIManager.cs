using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Panels
    [SerializeField] private Animation finishPanel;
    #endregion

    #region Buttons
    [SerializeField] private GameObject restartButton;
    #endregion

    [SerializeField] private TextMeshProUGUI totalScoreUI;
    [SerializeField] private TextMeshProUGUI finishPlayerResult;

    public static UIManager instance = null;
    void Start()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        #endregion
    }

    public void ShowFinishPanel()
    {
        finishPanel.Play("ShowResultPanel");
    }

    public void UpdateScoreUI()
    {
        totalScoreUI.text = $"{Player.instance.GetTotalScore()}";
    }

    public void UpdateStatus()
    {
        PlayerStatuses currentPlayerStatus = Player.instance.GetStatus();
        switch (currentPlayerStatus)
        {
            case PlayerStatuses.PlayerWin:
                finishPlayerResult.text = "������!";
                break;
            case PlayerStatuses.PlayerLose:
                finishPlayerResult.text = "���������!";
                break;
            default:
                break;
        }
    }
}