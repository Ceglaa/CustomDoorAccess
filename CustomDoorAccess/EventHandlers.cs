using System;
using System.Collections.Generic;
using EXILED;
using EXILED.Extensions;

namespace CustomDoorAccess
{
    public class EventHandlers
    {
        public Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void OnDoorInteract(ref DoorInteractionEvent ev)
        {

            var ply = ev.Player;

            foreach (KeyValuePair<string,string> x in Plugin.accessSet)
            {

                if (ev.Door.DoorName.Equals(x.Key))
                {
                    string trimmedValue = x.Value.Trim();
                    string[] itemIDs = trimmedValue.Split('&');

                    foreach (string eachValue in itemIDs)
                    {
                        int currentItem = Array.FindIndex(ply.inventory.availableItems,
                            r => r.id == ply.inventory.curItem);

                        if (Int32.TryParse(eachValue, out int itemID))
                        {
                            if (currentItem.Equals(itemID) && !currentItem.Equals(-1))
                            {
                                ev.Allow = true;
                            }
                            else if (Plugin.revokeAll && !itemIDs.Contains(currentItem.ToString()))
                            {
                                ev.Allow = false;
                                if (Plugin.scpAccess)
                                {
                                    foreach (string scpAccessDoor in Plugin.scpAccessDoors)
                                    {
                                        if (ev.Door.DoorName.Equals(scpAccessDoor))
                                        {
                                            if (ply.characterClassManager.IsAnyScp())
                                            {
                                                ev.Allow = true;
                                            }
                                        }
                                    }
                                }
                                else if(ply.serverRoles.BypassMode)
                                {
                                    ev.Allow = true;
                                }
                            }
                        }
                        else
                        {
                            Log.Error(x.Value + " is not a int.");
                        }
                    }
                }
            }
        }
    }
}