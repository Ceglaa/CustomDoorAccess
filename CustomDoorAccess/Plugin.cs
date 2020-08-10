using System;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Log = Exiled.API.Features.Log;

namespace CustomDoorAccess
{
    public class CdaPlugin : Plugin<Configs>
    {
        public EventHandlers _eventHandlers;
        public override string Author { get; } = "Faety";
        public override Version RequiredExiledVersion { get; } = new Version(2, 0, 0);
        public override string Prefix { get; } = "cda";
        public override string Name { get; } = "CustomDoorAccess";
        
        public override void OnEnabled()
        {
            if (!Config.IsEnabled)
            {
                Log.Info("CustomDoorAccess is disabled via configs. It will not be loaded.");
                return;
            }
            _eventHandlers = new EventHandlers(this);
            Player.InteractingDoor += _eventHandlers.OnDoorInteract;
        }

        public override void OnDisabled()
        {
            Player.InteractingDoor -= _eventHandlers.OnDoorInteract;
            _eventHandlers = null;
        }
    }
}