using ValtersVariousClasses.Cards;
using ValtersVariousClasses.MonoBehaviours;
using UnityEngine;

namespace ValtersVariousClasses.Extensions
{
    public static class CustomEffects
    {
        public static void DestroyAllEffects(GameObject gameObject)
        {
            DestroyAllAppliedEffects(gameObject);
        }
        public static void DestroyAllAppliedEffects(GameObject gameObject)
        {
            
            SpawnBulletsEffect[] spawnBulletsEffects = gameObject.GetComponents<SpawnBulletsEffect>();
            foreach (SpawnBulletsEffect spawnBulletsEffect in spawnBulletsEffects) { if (spawnBulletsEffect != null) { spawnBulletsEffect.Destroy(); } }
            
        }
        public static void DestroyAllRandomCardEffects(GameObject gameObject)
        {
            
        }
    }
}