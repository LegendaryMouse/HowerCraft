using Discord;
using UnityEngine;

public class Discord_Controller : MonoBehaviour
{
    public long applicationID;
    [Space]
    public string details = "Playing the best game in the world";
    public string state = "Current HP: ";
    [Space]
    public string largeImage = "0457caa32a20e8d9";
    public string largeText = "HowerCraft v0.0.7";

    public GameObject core;
    long time;

    static bool instanceExists;
    public Discord.Discord discord;

    void Start()
    {
        // Log in with the Application ID
        discord = new Discord.Discord(applicationID, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);

        time = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();

        UpdateStatus();
    }

    void Update()
    {
        // Destroy the GameObject if Discord isn't running
        try
        {
            discord.RunCallbacks();
        }
        catch
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        UpdateStatus();
        //Debug.Log(time);
    }

    void UpdateStatus()
    {
        Debug.Log("up ok " + state + (Mathf.Round(core.GetComponent<TotalHp>().deltaHp * 100)));

        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {

            Details = details,
            State = state + (Mathf.Round(core.GetComponent<TotalHp>().deltaHp * 100)) + "%",
            Assets =
                {
                    LargeImage = largeImage,
                    LargeText = largeText,
                    SmallImage = largeImage,
                    SmallText = "for cool guys only"
                },
            Timestamps =
                {
                    Start = time
                },
            Type = ActivityType.Listening,

            Secrets =
                {
                    Spectate = "spectate_secret_key",
                    Join = "join_secret_key"
                },
            /*Party =
                {

                    Id = "https://discord.gg/cHmd88BKBw",
                    Size =
                    {
                        CurrentSize = 34,
                        MaxSize = 100
                    }
                },*/
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res != Discord.Result.Ok) Debug.LogWarning("Failed connecting to Discord!");
        });
    }
}