using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace ValtersVariousClasses.Cards.Demolitionist
{
    class RocketBarrage : CustomCard
    {
        float burstsAmmountCalc;
        internal static CardInfo Card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.categories = new CardCategory[]
            {
                CustomCardCategories.instance.CardCategory("Ammunitions")
            };
            cardInfo.allowMultiple = false;
            gun.timeBetweenBullets = 0.05f;
            gun.reloadTimeAdd = -0.10f;
            
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            UnityEngine.Debug.Log($"[{ValtersVariousClasses.ModInitials}][Card] {GetTitle()} has been setup.");
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            UnityEngine.Debug.Log($"[{ValtersVariousClasses.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
            burstsAmmountCalc = gunAmmo.maxAmmo / 4;
            if (burstsAmmountCalc % 1 != 0)
            {
                burstsAmmountCalc += 1;
                burstsAmmountCalc = burstsAmmountCalc / 4;
                if (burstsAmmountCalc % 1 != 0)
                {
                    burstsAmmountCalc += 1;
                    burstsAmmountCalc = burstsAmmountCalc / 4;
                }
            }


            gun.bursts = (int) burstsAmmountCalc;
            gun.reloadTime *= 2;
            

        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            UnityEngine.Debug.Log($"[{ValtersVariousClasses.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }
        protected override string GetTitle()
        {
            return "Rocket Barrage";
        }
        protected override string GetDescription()
        {
            return "Fire 1/4 of your clip each time you fire";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Fire Rate",
                    amount = "slightly faster",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "ammo",
                    amount = "+1",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Reload Speed",
                    amount = "a lot more",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
                
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.FirepowerYellow;
        }
        public override string GetModName()
        {
            return ValtersVariousClasses.ModInitials;
        }
    }

}
