using System;
using UnityEngine;

namespace Unity.VisualScripting
{
    [Plugin(BoltState.ID)]
    internal class Migration_1_5_1_to_1_5_2 : PluginMigration
    {
        internal Migration_1_5_1_to_1_5_2(Plugin plugin) : base(plugin)
        {
            order = 1;
        }

        public override SemanticVersion @from => "1.5.1";
        public override SemanticVersion to => "1.5.2";

        public override void Run()
        {
            try
            {
                MigrateProjectSettings();
            }
#pragma warning disable 168
            catch (Exception e)
#pragma warning restore 168
            {
                Debug.LogWarning("There was a problem migrating your Visual Scripting project settings. Be sure to check them in Edit -> Project Settings -> Visual Scripting");
#if VISUAL_SCRIPT_DEBUG_MIGRATION
                Debug.LogError(e);
#endif
            }
        }

        private static void MigrateProjectSettings()
        {
            BoltState.Configuration.LoadOrCreateProjectSettingsAsset();

            var legacyProjectSettingsAsset = MigrationUtility_1_5_1_to_1_5_2.GetLegacyProjectSettingsAsset("VisualScripting.State");
            if (legacyProjectSettingsAsset != null)
            {
                BoltState.Configuration.projectSettingsAsset.Merge(legacyProjectSettingsAsset);
            }

            BoltState.Configuration.SaveProjectSettingsAsset(true);
            BoltState.Configuration.ResetProjectSettingsMetadata();
        }
    }

    [Plugin(BoltState.ID)]
    internal class DeprecatedSavedVersionLoader_1_5_1 : PluginDeprecatedSavedVersionLoader
    {
        internal DeprecatedSavedVersionLoader_1_5_1(Plugin plugin) : base(plugin) { }

        public override SemanticVersion @from => "1.5.1";

        public override bool Run(out SemanticVersion savedVersion)
        {
            var manuallyParsedVersion = MigrationUtility_1_5_1_to_1_5_2.TryManualParseSavedVersion("VisualScripting.State");
            savedVersion = manuallyParsedVersion;

            return savedVersion != "0.0.0";
        }
    }
}
