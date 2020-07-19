using System;
using System.Collections.Generic;
using System.Linq;
using EXILED;

namespace CustomDoorAccess
{
    public class Plugin : EXILED.Plugin
    {
        public EventHandlers EventHandlers;
        public static Dictionary<string, string> accessSet;
        public static bool revokeAll;
        public static bool scpAccess;
        public static List<string> scpAccessDoors;

        public override void OnEnable()
        {
            ReloadConfigs();
            
            EventHandlers = new EventHandlers(this);
            Events.DoorInteractEvent += EventHandlers.OnDoorInteract;
        }

        private void ReloadConfigs()
        {
            try
            {
                accessSet = Config.GetString("cda_access_set", string.Empty).Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(part => part.Split(':'))
                    .ToDictionary(split => split[0], split => split[1]);
                revokeAll = Config.GetBool("cda_revoke_all", false);
                scpAccess = Config.GetBool("cda_scp_access", false);
                scpAccessDoors = Config.GetString("cda_scp_access_doors", string.Empty).Split(',').ToList();
            }
            catch (Exception e)
            {
                Log.Error("Error: " + e.Message);
                Log.Error("It seems like you have an error with your configs, check https://github.com/Faeety/CustomDoorAccess for more infos.");
            }
        }

        public override void OnDisable()
        {
            Events.DoorInteractEvent -= EventHandlers.OnDoorInteract;
            EventHandlers = null;
        }

        public override void OnReload()
        {
            
        }

        public override string getName { get; } = "CustomDoorAccess";
    }
}