using System;
using System.Collections.Generic;
using System.Linq;
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
            
            if (!ev.Door.gameObject.TryGetComponent(out DoorNametagExtension _)) return;
            var doorName = ev.Door.gameObject.GetComponent<DoorNametagExtension>().GetName;
            var accessSet = _plugin.Config.AccessSet;
            
            if (accessSet.TryGetValue(doorName, out var valueName))
            {
                    string trimmedValue = valueName.Trim();
                    string[] itemIDs = trimmedValue.Split('&');

                    foreach (string eachValue in itemIDs)
                    {
                        int currentItem = (int) ply.Inventory.curItem;

                        if (int.TryParse(eachValue, out int itemId))
                        {
                            if(ply.IsBypassModeEnabled)
                            {
                                ev.IsAllowed = true;
                                return;
                            }

                            if (_plugin.Config.Scp079Bypass && ply.Role.Equals(RoleType.Scp079))
                            {
                                ev.IsAllowed = true;
                                return;
                            }
                            
                            if (currentItem.Equals(itemId) && !currentItem.Equals(-1))
                            {
                                ev.IsAllowed = true;
                                return;
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
                                            return;
                                        }
                                    }
                                }
                            }
                            
                            if (_plugin.Config.RevokeAll && !itemIDs.Contains(currentItem.ToString()))
                            {
                                ev.IsAllowed = false;
                                return;
                            }
                        }
                        else
                        {
                            Log.Error(valueName + " is not a int.");
                        }
                    }
            }
        }

        public void OnGeneratorUnlock(UnlockingGeneratorEventArgs ev)
        {
            if (!_plugin.Config.GeneratorAccess.Any()) return;
            var currItem = (int) ev.Player.Inventory.curItem;
            var configItemList = _plugin.Config.GeneratorAccess;

            ev.IsAllowed = configItemList.Contains(currItem);
        }

        public void OnElevatorInteraction(InteractingElevatorEventArgs ev)
        {
            var ply = ev.Player;
            var elevatorAccess = _plugin.Config.ElevatorAccess;
            string elevatorName;
            switch (ev.Lift.elevatorName)
            {
                case "GateA":
                    elevatorName = "GateA";
                    break;
                case "GateB":
                    elevatorName = "GateB";
                    break;
                case "SCP-049":
                    elevatorName = "Scp049";
                    break;
                case "ElA":
                    elevatorName = "SystemA";
                    break;
                case "ElB":
                    elevatorName = "SystemB";
                    break;
                case "ElA2":
                    elevatorName = "SystemA";
                    break;
                case "ElB2":
                    elevatorName = "SystemB";
                    break;
                default:
                    elevatorName = "Nuke";
                    break;
            }
            
            if(elevatorAccess.Keys.Count == 0) return;
            if (elevatorAccess.TryGetValue(elevatorName, out var elevatorValue))
            {
                string trimmedValue = elevatorValue.Trim();
                string[] itemIDs = trimmedValue.Split('&');

                foreach (var eachValue in itemIDs)
                {
                    int currentItem = (int) ply.Inventory.curItem;

                    if (int.TryParse(eachValue, out int itemId))
                    {
                        if(ply.IsBypassModeEnabled)
                        {
                            ev.IsAllowed = true;
                            return;
                        }
                        
                        if (ply.ReferenceHub.characterClassManager.IsAnyScp())
                        {
                            ev.IsAllowed = true;
                            return;
                        }
                        
                        if (currentItem.Equals(itemId) && !currentItem.Equals(-1))
                        {
                            ply.ShowHint("<color=green>ACCESS GRANTED</color>");
                            ev.IsAllowed = true;
                            return;
                        }
                        
                        if (!itemIDs.Contains(currentItem.ToString()))
                        {
                            ply.ShowHint("<color=red>ACCESS DENIED</color>");
                            ev.IsAllowed = false;
                            return;
                        }
                    }
                    else
                    {
                        Log.Error(elevatorValue + " is not a int.");
                    }
                }
            }
        }
    }
}