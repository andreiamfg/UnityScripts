using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;


public class UGS_Analytics : MonoBehaviour
{
    async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();
            GiveConsent();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    public void PlayerActionEvent(string actionID)
    {

        PlayerActionEvent e = new PlayerActionEvent();
        e.ActionID = actionID;

        AnalyticsService.Instance.RecordEvent(e);
    }

    public void GiveConsent()
    {
        AnalyticsService.Instance.StartDataCollection();
    }

}

public class PlayerActionEvent : Unity.Services.Analytics.Event
{
    public PlayerActionEvent(): base("playerAction")
    {

    }
    public string ActionID { set { SetParameter("actionID", value); } }

}