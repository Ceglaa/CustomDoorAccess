using System;
using System.Collections.Generic;
using Exiled.API.Extensions;
using Exiled.Events.EventArgs;
using Interactables.Interobjects.DoorUtils;
using Log = Exiled.API.Features.Log;

namespace CustomDoorAccess
{
    public class EventHandlers
    {
        private readonly CdaPlugin _plugin;
        public EventHandlers(CdaPlugin plugin) => _plugin = plugin;

        public void OnDoorInteract(InteractingDoorEventArgs ev)
        {
            var ply = ev.Player;
            if (!ev.Door.gameObject.TryGetComponent<DoorNametagExtension>(out DoorNametagExtension doorTag)) return;
            var doorName = ev.Door.gameObject.GetComponent<DoorNametagExtension>().GetName;
            foreach (KeyValuePair<string,string> x in _plugin.Config.AccessSet)
            {

                if (doorName.Equals(x.Key))
                {
                    string trimmedValue = x.Value.Trim();
                    string[] itemIDs = trimmedValue.Split('&');

                    foreach (string eachValue in itemIDs)
                    {
                        int currentItem = Array.FindIndex(ply.Inventory.availableItems,
                            r => r.id == ply.CurrentItem.id);

                        if (int.TryParse(eachValue, out int itemId))
                        {
                            if (currentItem.Equals(itemId) && !currentItem.Equals(-1))
                            {
                                ev.IsAllowed = true;
                            }
                            else if(ply.IsBypassModeEnabled)
                            {
                                ev.IsAllowed = true;
                            }
                            
                            if (_plugin.Config.RevokeAll && !itemIDs.Contains(currentItem.ToString()))
                            {
                                ev.IsAllowed = false;
                            }
                            
                            if (_plugin.Config.ScpAccess)
                            {
                                foreach (string scpAccessDoor in _plugin.Config.ScpAccessDoors)
                                {
                                    if (doorName.Equals(scpAccessDoor))
                                    {
                                        if (ply.ReferenceHub.characterClassManager.IsAnyScp())
                                        {
                                            ev.IsAllowed = true;
                                        }
                                    }
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