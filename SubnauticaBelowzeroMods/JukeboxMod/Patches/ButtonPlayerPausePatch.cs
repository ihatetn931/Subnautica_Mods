using HarmonyLib;
using Story;
using System.IO;
using UnityEngine;

namespace JukeBoxMod.Patches
{
	[HarmonyPatch(typeof(JukeboxInstance), nameof(JukeboxInstance.OnButtonPlayPause))]
	internal class OnButtonPlayPausePatch
	{
		public static bool Prefix(JukeboxInstance __instance)
		{
			if (string.IsNullOrEmpty(__instance.file) || !Jukebox.HasFile(__instance._file))
			{
				__instance.SwitchTrack(true);
			}
			if (__instance.isControlling && Jukebox.isStartingOrPlaying)
			{
				MainPatch.isPaused = !Jukebox.paused;
				ErrorMessage.AddDebug("Paused: " + Jukebox.paused);
				Jukebox.paused = !Jukebox.paused;
			}
			else if (__instance.ConsumePower())
			{
				Jukebox.Play(__instance);
				Jukebox.TrackInfo info = Jukebox.GetInfo(__instance.file);
				__instance.SetLabel(info.label);
				__instance.SetLength(info.length);
				MainPatch.isPlaying = true;
				MainPatch.isPaused = false;
			}
			else
			{
				__instance.SetLabel(Language.main.Get("JukeboxNoPower"));
			}
			if (StoryGoalManager.main.IsAlanOnboard())
			{
				StoryGoal.Execute("Log_Alan_Aside_JukeboxMusic", Story.GoalType.PDA, true, false);
			}
			return false;
		}
	}
	/*[HarmonyPatch(typeof(SubRoot), nameof(SubRoot.UpdateLighting))]
	internal class SubRootUpdateLightPatch
	{
		public static bool Prefix(SubRoot __instance)
		{
			if (__instance.lightControl != null)
			{
				__instance.lightingState = 0;
				if (__instance.IsLeaking() || __instance.silentRunning || __instance.subWarning || __instance.fireSuppressionState)
				{
					__instance.lightingState = 1;
				}
				if (__instance.powerRelay != null)
				{
					ErrorMessage.AddDebug("myTest: " + OnButtonPlayPausePatch.myTest);
					if (OnButtonPlayPausePatch.myTest == true)
					{
						__instance.lightingState = 2;
					}
					/*if (__instance.powerRelay.GetPowerStatus() == PowerSystem.Status.Offline || !__instance.subLightsOn)
					{
						__instance.lightingState = 2;
					}
					if (__instance.live && !__instance.live.IsAlive())
					{
						__instance.lightingState = 2;
					}
				}
				if (__instance.lightingState != (int)__instance.lightControl.state)
				{
					__instance.lightControl.LerpToState(__instance.lightingState);
				}
			}

			return false;
		}
	}*/
}