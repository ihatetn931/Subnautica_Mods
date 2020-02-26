/*namespace BetterSeaglide.Patches
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    // Code adapted from the original CyclopsNearFieldSonar mod by frigidpenguin
    internal class CySonarComponent : MonoBehaviour
    {
        private static IEnumerator<YieldInstruction> EachFrameUntil(Func<bool> action)
        {
            while (!action())
            {
                yield return null;
            }
        }

        private readonly GameObject template = CraftData.GetPrefabForTechType(TechType.CyclopsSonarModule);

        public void SetMapState(bool state)
        {
            if (state)
                script?.EnableMap();
            else
                script?.DisableMap();
        }

        private const float scale = 6.699605f;
        private const float fadeRadius = 1.503953f;
        private const float shipScale = 0.2f;
        private readonly Vector3 position = new Vector3(-0.9762846f, 2, -10.6917f);
        private readonly Vector3 shipPosition = new Vector3(0, 0, 0);

        private CyclopsHUDSonarPing script;
        private Material material;
        private GameObject ship;

        private void Start()
        {
            Transform root = gameObject.transform.Find("SonarMap_Small");
            var holder = new GameObject("NearFieldSonar");
            holder.transform.SetParent(root, false);
            holder.transform.localScale = Vector3.one * 0.1f;

            GameObject prefab = template.GetComponent<CyclopsSonarCreatureDetector>().sonarDisplay.gameObject;
            var hologram = GameObject.Instantiate(prefab);
            hologram.transform.SetParent(holder.transform, false);

            script = hologram.GetComponentInChildren<CyclopsHUDSonarPing>();
            script.enabled = true;
            //script.enEnableMap();

            StartCoroutine(EachFrameUntil(() =>
            {
                
                foreach(var mat in script.mats )
                {
                    material = mat;
                }
                //material = script.mats;
                return UpdateParameters();
            }));

            ship = GameObject.Instantiate(this.gameObject.transform.Find("HolographicDisplay/CyclopsMini_Mid").gameObject);
            ship.transform.SetParent(root, false);

            MeshRenderer[] cyclopsMeshRenderers = ship.transform.GetComponentsInChildren<MeshRenderer>();

            foreach (MeshRenderer meshRenderer in cyclopsMeshRenderers)
            {
                if (meshRenderer.gameObject.name.StartsWith("cyclops_room_"))
                {
                    meshRenderer.enabled = false;
                }
            }

            MeshRenderer oldShipRenderer = root.Find("CyclopsMini").GetComponent<MeshRenderer>();
            Material shipMaterial = oldShipRenderer.material;

            foreach (MeshRenderer meshRenderer in cyclopsMeshRenderers)
                meshRenderer.sharedMaterial = shipMaterial;

            oldShipRenderer.enabled = false;
            root.Find("Base").GetComponent<MeshRenderer>().enabled = false;
        }

        private bool UpdateParameters()
        {
            if (material == null)
                return false;

            script.pingBase.transform.localScale = Vector3.one * scale;
            script.pingTop.transform.localPosition = position * (1 / scale);

            material.SetFloat("_FadeRadius", fadeRadius);

            ship.transform.localPosition = shipPosition;
            ship.transform.localScale = Vector3.one * shipScale;

            return true;
        }
    }
}*/