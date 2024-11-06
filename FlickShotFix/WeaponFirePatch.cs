using Gear;
using HarmonyLib;
using Player;

namespace FlickShotFix
{
    [HarmonyPatch]
    internal static class WeaponFirePatch
    {
        private static FPSCamera? _camera;

        [HarmonyPatch(typeof(Shotgun), nameof(Shotgun.Fire))]
        [HarmonyPatch(typeof(BulletWeapon), nameof(BulletWeapon.Fire))]
        [HarmonyPrefix]
        private static void PreFire()
        {
            if (_camera == null)
                _camera = PlayerManager.GetLocalPlayerAgent().FPSCamera;
            _camera.UpdateCameraRay();
        }
    }
}
