using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace CustomDoorAccess
{
    public class Configs : IConfig
    {
        [Description("Enable or disable CustomDoorAccess.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Allow or disallow revocation of the access to all the other keycards.")]
        public bool RevokeAll { get; set; } = false;

        [Description("Allow or disallow SCPs to open doors that you set with scp_access_doors.")]
        public bool ScpAccess { get; set; } = false;

        [Description("Gives access to the door with the item(s) that you set.")]
        public Dictionary<string, string> AccessSet { get; set; } =
            new Dictionary<string, string> {{"012", "0"}, {"914", "0"}, {"INTERCOM", "5&7"}};

        [Description("List of the doors that SCPs can open. Only works if door is edited on the access_set config.")]
        public List<string> ScpAccessDoors { get; set; } = new List<string> { "CHECKPOINT_LCZ_A", "CHECKPOINT_LCZ_B", "CHECKPOINT_EZ_HCZ" };

        [Description("Allow or disallow SCP-079 bypass.")]
        public bool Scp079Bypass { get; set; } = false;
    }
}