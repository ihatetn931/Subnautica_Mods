using HarmonyLib;
using Story;
using System.Collections.Generic;
using UnityEngine;

namespace JukeBoxMod.Patches
{
	[HarmonyPatch(typeof(JukeboxInstance), nameof(JukeboxInstance.OnButtonStop))]
	internal class JukeboxOnButtonStopPatch
	{
		public static bool Prefix(JukeboxInstance __instance)
		{
			__instance.imagePlayPause.sprite = __instance.spritePlay;
			if (__instance.isControlling)
			{
				Jukebox.Stop();
				MainPatch.isPlaying = false;
				MainPatch.isPaused = false;
			}
			return false;
		}
	}
}