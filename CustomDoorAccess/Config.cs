using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace CustomDoorAccess
{
    public class Configs : IConfig
    {
        [Description("Enable or not CustomDoorAccess.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Revoke the access to all the others cards or not.")]
        public bool RevokeAll { get; set; } = false;

        [Description("Allow SCPs to open doors that you set with cda_scp_access_doors.")]
        public bool ScpAccess { get; set; } = false;

        [Description("Gives access to the door with the item(s) that you set.")]
        public Dictionary<string, string> AccessSet { get; set; } =
            new Dictionary<string, string> {{"012", "0"}, {"914", "0"}, {"INTERCOM", "5&7"}};

        [Description("Set the doors that SCPs can open.")]
        public List<string> ScpAccessDoors { get; set; } = new List<string> { "CHECKPOINT_LCZ_A", "CHECKPOINT_LCZ_B", "CHECKPOINT_ENT" };
    }
}