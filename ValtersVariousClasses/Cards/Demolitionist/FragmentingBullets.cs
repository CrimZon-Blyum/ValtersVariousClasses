using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValtersVariousClasses.Extensions;
using ValtersVariousClasses.MonoBehaviours;
using ValtersVariousClasses.Utils;
using ValtersVariousClasses.Effects;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace ValtersVariousClasses.Cards.Demolitionist
{
    internal class FragmentingBullets : CustomCard
    {
        internal static CardInfo Card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            UnityEngine.Debug.Log($"[{ValtersVariousClasses.ModInitials}][Card] {GetTitle()} has been setup.");
            
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            UnityEngine.Debug.Log($"[{ValtersVariousClasses.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
            FragmentationHitSurfaceEffect hitEffect = player.gameObject.GetOrAddComponent<FragmentationHitSurfaceEffect>();
            hitEffect.shrapnel += 3;
            hitEffect.amount++;
            gun.GetAdditionalData().fragmentationProjectiles += 3;
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            UnityEngine.Debug.Log($"[{ValtersVariousClasses.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
            FragmentationHitSurfaceEffect hitEffect = player.gameObject.GetComponent<FragmentationHitSurfaceEffect>();
            if (hitEffect.amount <= 0)
            {
                UnityEngine.GameObject.Destroy(hitEffect);
            }
        }
        protected override string GetTitle()
        {
            return "Fragmenting Bullets";
        }
        protected override string GetDescription()
        {
            return "When bullets hit, they produce shrapnel";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Shrapnel",
                    amount = "+3",
                    simepleAmount = CardInfoStat.SimpleAmount.Some
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "damage",
                    amount = "10% more",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return ValtersVariousClasses.ModInitials;
        }
 
    }
}
