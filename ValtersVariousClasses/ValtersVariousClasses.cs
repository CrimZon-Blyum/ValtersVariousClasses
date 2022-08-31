using BepInEx;
using ClassesManagerReborn;
using UnboundLib;
using UnboundLib.Cards;
using ValtersVariousClasses.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using ValtersVariousClasses.Cards.Demolitionist;
using RocketBarrage = ValtersVariousClasses.Cards.Demolitionist.RocketBarrage;
using FragmentingBullets = ValtersVariousClasses.Cards.Demolitionist.FragmentingBullets;

namespace ValtersVariousClasses
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class ValtersVariousClasses : BaseUnityPlugin
    {
        
        private const string ModId = "com.CrimzonBlyum.rounds.ValtersVariousClasses";
        private const string ModName = "Valter's Various Classes";
        public const string Version = "0.0.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "VVC";

        public static ValtersVariousClasses? instance { get; private set; }

        private void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }

        private void Start()
        {
            instance = this;
            CustomCard.BuildCard<RocketBarrage>((card) => RocketBarrage.Card = card);
            CustomCard.BuildCard<FragmentingBullets>((card) => FragmentingBullets.Card = card);
        }
    }

}
