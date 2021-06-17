using HarmonyLib;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace JukeBoxMod.Patches
{
	[HarmonyPatch(typeof(JukeboxInstance), nameof(JukeboxInstance.UpdateEffects))]
	internal class JukeboxInstanceUpdateEffectsPatch
	{
		public static Material Mat;
		public static BaseCellLighting light;
		public static bool Prefix(JukeboxInstance __instance)
		{
			if (__instance._materials == null)
			{
				return false;
			}
			float num = __instance._flashValue;
			float num2 = __instance._highValue;
			if (__instance.isControlling)
			{
				float num3 = 0f;
				float num4 = 0f;
				List<float> spectrum = Jukebox.spectrum;
				if (spectrum != null && spectrum.Count > 0)
				{
					int num5 = Mathf.Min(2, spectrum.Count);
					for (int i = 0; i < num5; i++)
					{
						float b = spectrum[i];
						num3 = Mathf.Max(num3, b);
					}
					int count = spectrum.Count;
					for (int j = num5; j < count; j++)
					{
						float b2 = spectrum[j];
						num4 = Mathf.Max(num4, b2);
					}
				}
				if (num < num3)
				{
					num = num3;
				}
				else
				{
					num = Mathf.SmoothDamp(num, num3, ref __instance._flashVelocity, 0.2f, float.PositiveInfinity, Time.deltaTime);
				}
				if (num2 < num4)
				{
					num2 = num4;
				}
				else
				{
					num2 = Mathf.SmoothDamp(num2, num4, ref __instance._highVelocity, 0.05f, float.PositiveInfinity, Time.deltaTime);
				}
				num = Mathf.Clamp(num, 0.2f, 1f);
				num2 = Mathf.Clamp01(num2 * 1.75f) * 0.39999998f + 0.6f;
			}
			else if (num != 0f)
			{
				num = 0f;
				__instance._flashVelocity = 0f;
			}
			else if (num2 != 0f)
			{
				num2 = 0f;
				__instance._highVelocity = 0f;
			}
			if (__instance._highValue != num2)
			{
				Color value;
				__instance._highValue = num2;
				if (JukeboxConfig.JBColor)
				{
					value = Color.Lerp(JukeboxConfig.FlashColor0, JukeboxConfig.FlashColor2, __instance._highValue);
				}
				else
				{
					value = Color.Lerp(__instance.flashColor0, __instance.flashColor2, __instance._highValue);
				}
				__instance._materials[1].SetColor(ShaderPropertyID._Color, value);
			}
			if (__instance._flashValue != num)
			{
				Color value2;
				if (JukeboxConfig.JBColor)
				{
					value2 = Color.Lerp(JukeboxConfig.FlashColor0, JukeboxConfig.FlashColor1, __instance._flashValue);
				}
				else
				{
					value2 = Color.Lerp(__instance.flashColor0, __instance.flashColor1, __instance._flashValue);
				}
				__instance._flashValue = num;
				__instance._materials[1].SetColor(ShaderPropertyID._GlowColor, value2);
			}

			var subRoot = __instance._baseComp;
			light = subRoot.GetCellLightingFor(__instance.transform.position);
			ErrorMessage.AddDebug("LL: " + light.name);
			var color0 = new Color(__instance.flashColor0.r, __instance.flashColor0.g, __instance.flashColor0.b, 1);
			var color1 = new Color(__instance.flashColor1.r, __instance.flashColor1.g, __instance.flashColor1.b, 1);
			var color2 = new Color(JukeboxConfig.FlashColor0.r, JukeboxConfig.FlashColor0.g, JukeboxConfig.FlashColor0.b, 1);
			var color3 = new Color(JukeboxConfig.FlashColor1.r, JukeboxConfig.FlashColor1.g, JukeboxConfig.FlashColor1.b, 1);
			//var color4 = new Color(JukeboxConfig.FlashColor2.r, JukeboxConfig.FlashColor2.g, JukeboxConfig.FlashColor2.b, 1);
			//string file = "Logs/test.txt";
			if (light != null && JukeboxConfig.PartyMode)
			{
				foreach (var l in light.interior)
				{
					foreach (var mat in l.materials)
					{
						Color flashValue;
						Mat = mat;
						if (JukeboxConfig.JBColor)
						{
							flashValue = Color.Lerp(color2, color3, __instance._flashValue);
						}
						else
						{
							flashValue = Color.Lerp(color0, color1, __instance._flashValue);
						}
						if (MainPatch.isPlaying && !MainPatch.isPaused)
						{
							if (!Mat.name.Contains("window")
								&& !Mat.name.Contains("glass")
								&& !Mat.name.Contains("WaterPlaneBaseCorridor")
								&& !Mat.name.Contains("WaterRunOnWall")
								&& !Mat.name.Contains("WaterPlaneBaseRoomObs")
								&& !Mat.name.Contains("x_BaseWaterFog_BaseRoom")
								&& !Mat.name.Contains("x_BaseWaterFog_RoomCorridorConnector")
								&& !Mat.name.Contains("Juke"))
							{
								/*if (!File.Exists(file))
									File.Create(file);
								if (!File.ReadAllText(file).Contains(Mat.name))
								{
									File.AppendAllText(file, "Name: " + string.Join(",", mat.name) + " \n");
								}*/
								mat.color = flashValue;
								light.currentIntensity = Mathf.Clamp(__instance._flashValue, 0, 1);
								light.ApplyCurrentIntensity();
							}

						}
						if (MainPatch.isPaused && !MainPatch.isPlaying)
						{
							if (!Mat.name.Contains("window")
								&& !Mat.name.Contains("glass")
								&& !Mat.name.Contains("WaterPlaneBaseCorridor")
								&& !Mat.name.Contains("WaterRunOnWall")
								&& !Mat.name.Contains("WaterPlaneBaseRoomObs")
								&& !Mat.name.Contains("x_BaseWaterFog_BaseRoom")
								&& !Mat.name.Contains("x_BaseWaterFog_RoomCorridorConnector")
								&& !Mat.name.Contains("Juke"))
							{
								Mat.color = Color.white;
								light.currentIntensity = 1;
								light.ApplyCurrentIntensity();
							}
						}
						if (!MainPatch.isPlaying && !MainPatch.isPaused)
						{
							if (!Mat.name.Contains("window")
								&& !Mat.name.Contains("glass")
								&& !Mat.name.Contains("WaterPlaneBaseCorridor")
								&& !Mat.name.Contains("WaterRunOnWall")
								&& !Mat.name.Contains("WaterPlaneBaseRoomObs")
								&& !Mat.name.Contains("x_BaseWaterFog_BaseRoom")
								&& !Mat.name.Contains("x_BaseWaterFog_RoomCorridorConnector")
								&& !Mat.name.Contains("Juke"))
							{
								Mat.color = Color.white;
								light.currentIntensity = 1;
								light.ApplyCurrentIntensity();
							}
						}
					}
				}
			}
			else
			{
				if (!Mat.name.Contains("window")
					&& !Mat.name.Contains("glass")
					&& !Mat.name.Contains("WaterPlaneBaseCorridor")
					&& !Mat.name.Contains("WaterRunOnWall")
					&& !Mat.name.Contains("WaterPlaneBaseRoomObs")
					&& !Mat.name.Contains("x_BaseWaterFog_BaseRoom")
					&& !Mat.name.Contains("x_BaseWaterFog_RoomCorridorConnector")
					&& !Mat.name.Contains("Juke")
					&& !JukeboxConfig.PartyMode)
				{
					Mat.color = Color.white;
					light.currentIntensity = 1;
					light.ApplyCurrentIntensity();
				}
			}
			return false;
		}
	}
}
