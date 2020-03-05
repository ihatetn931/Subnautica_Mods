using SMLHelper.V2.Crafting;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Handlers;
using UnityEngine;
using System.Collections.Generic;

namespace BetterSeaglide
{
    public abstract class BetterSeaGlide : ModPrefab
    {

        public static TechType BetterSeaglide { get; protected set; }

        public readonly string ID;
        public readonly string DisplayName;
        public readonly string Tooltip;
        public readonly TechType RequiredForUnlock;
        public readonly CraftTree.Type Fabricator;
        public readonly string[] StepsToTab;
        public readonly Atlas.Sprite Sprite;
        public readonly TechType AddAfter;

        protected BetterSeaGlide(string id, string displayName, string tooltip, CraftTree.Type fabricator, string[] stepsToTab, TechType requiredToUnlock = TechType.None, TechType addAfter = TechType.None, Atlas.Sprite sprite = null) : base(id, $"WorldEntities/Tools/", TechType.None)
        {
            ID = id;
            DisplayName = displayName;
            Tooltip = tooltip;
            Fabricator = fabricator;
            RequiredForUnlock = requiredToUnlock;
            StepsToTab = stepsToTab;
            Sprite = sprite;
            AddAfter = addAfter;

            Patch();
            Debug.Log($"Fabricator is {Fabricator}\n Path is {StepsToTab}\n Crafttree is {CraftTree.Type.Fabricator}");
        }

        public void Patch()
        {
            TechType = TechTypeHandler.AddTechType(ID, DisplayName, Tooltip, RequiredForUnlock == TechType.Seaglide);

            if (RequiredForUnlock != TechType.None)
                KnownTechHandler.SetAnalysisTechEntry(RequiredForUnlock, new TechType[] { TechType.PowerGlide });

            if (Sprite == null)
                SpriteHandler.RegisterSprite(TechType, $"./QMods/BetterSeaglide/Assets/powerglide.png");
            else
                SpriteHandler.RegisterSprite(TechType, Sprite);

            /*switch (Fabricator)
            {
                case CraftTree.Type.Fabricator:
                    CraftDataHandler.AddToGroup(TechGroup.Machines, TechCategory.Machines, TechType, AddAfter);
                    break;

            }*/

            //CraftDataHandler.AddToGroup(TechGroup.Machines, TechCategory.Machines, TechType, AddAfter);
            CraftDataHandler.SetEquipmentType(TechType, EquipmentType.Hand);
            CraftDataHandler.SetTechData(TechType, GetTechData());
            CraftDataHandler.SetQuickSlotType(TechType, QuickSlotType.Selectable);
            //CraftTreeHandler.AddTabNode(Fabricator, "Deployables", "Better Seaglide", SpriteManager.Get(BetterSeaglide));
            CraftTreeHandler.AddCraftingNode(Fabricator, TechType, StepsToTab);
        }

        public override GameObject GetGameObject()
        {
            // Get the ElectricalDefense module prefab and instantiate it
            var path = "WorldEntities/Tools/Seaglide";
            //var path = $"./QMods/BetterSeaglide/Assets/PowerGlide";
            var prefab = Resources.Load<GameObject>(path);
            var obj = GameObject.Instantiate(prefab);
            ErrorMessage.AddWarning($"Tree is {CraftTree.GetTree(CraftTree.Type.Fabricator)}");

            // Get the TechTags and PrefabIdentifiers
            var techTag = obj.GetComponent<TechTag>();
            var prefabIdentifier = obj.GetComponent<PrefabIdentifier>();

            // Change them so they fit to our requirements.
            techTag.type = TechType;
            prefabIdentifier.ClassId = ClassID;

            return obj;
        }

        public abstract TechData GetTechData();
    }



    public class BetterSeaglide : BetterSeaGlide
    {
        public BetterSeaglide() :
            base("BetterSeaglide",
                "Better Seaglide",
                "A seaglide with upgrades",
                CraftTree.Type.Fabricator,
                new string[1] { "Machines" },
                TechType.Seaglide,
                TechType.Seaglide,
                null)
        {
            BetterSeaglide = TechType;
        }

        public override TechData GetTechData()
        {
            return new TechData()
            {
                Ingredients = new List<Ingredient>()
                {
                    new Ingredient(TechType.Seaglide, 1),
                    new Ingredient(TechType.Titanium, 2),
                },
                craftAmount = 1
            };
        }
    }
}