using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

namespace DiscordSDK
{
	public class DiscordController : MonoBehaviour
	{

		public Discord.Discord discord;

		// Use this for initialization
		void Start()
		{
			discord = new Discord.Discord(461618159171141643, (System.UInt64)Discord.CreateFlags.Default);
			var activityManager = discord.GetActivityManager();
			var activity = new Discord.Activity
			{
				Assets =
				{
					LargeImage = "main"
				},
				Details = "In Menu"
			};
			activityManager.UpdateActivity(activity, (res) =>
			{
				if (res == Discord.Result.Ok)
				{
					Debug.LogError("Everything is fine!");
				}
			});
		}

		// Update is called once per frame
		void Update()
		{
			discord.RunCallbacks();
		}
	}
}