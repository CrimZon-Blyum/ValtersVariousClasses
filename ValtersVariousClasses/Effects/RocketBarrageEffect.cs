using System;
using ModdingUtils.MonoBehaviours;
using UnboundLib;

namespace ValtersVariousClasses.Effects
{
    public class RocketBarrageEffect : ReversibleEffect
    {
        internal int burstsAmmountCalc;
        public int HowMany = 0;
        public void AttackAction()
        {
            burstsAmmountCalc = gunAmmo.maxAmmo / 4;

            if ((int)burstsAmmountCalc <= 0)
            {
                burstsAmmountCalc = 1;
            }
            gun.numberOfProjectiles = (int)burstsAmmountCalc;
        }

        public override void OnStart()
        {
            base.OnStart();
            gun.AddAttackAction(AttackAction);
        }
        public override void OnOnDestroy()
        {
            base.OnOnDestroy();
            gun.InvokeMethod("RemoveAttackAction", (Action)AttackAction);
        }
    }
}
