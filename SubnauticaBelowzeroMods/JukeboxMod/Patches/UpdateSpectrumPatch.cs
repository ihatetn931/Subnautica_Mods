using HarmonyLib;
using System.Collections.Generic;

namespace JukeBoxMod.Patches
{
	/*[HarmonyPatch(typeof(JukeboxInstance), nameof(JukeboxInstance.UpdateSpectrum))]
	internal class JukeboxInstanceUpdateSpectrumPatch
	{
		public static bool Prefix(bool reset, JukeboxInstance __instance)
		{
			List<float> spectrum = Jukebox.spectrum;
			int num = __instance._materialsSpectrum.Length;
			float num2 = 0f;
			if (spectrum != null && spectrum.Count > 0)
			{
				num2 = (float)(spectrum.Count - 1) / (float)num;
			}
			else
			{
				reset = true;
			}
			for (int i = 0; i < num; i++)
			{
				float num3;
				if (reset)
				{
					num3 = 0f;
				}
				else
				{
					int index = (int)(num2 * (float)i);
					num3 = spectrum[index];
					num3 = FMODExtensions.RemapDb(FMODExtensions.LinearToDb(num3));
				}
				__instance._materialsSpectrum[i].SetFloat(ShaderPropertyID._Amount, num3);
			}
			return false;
		}
	}*/
}
