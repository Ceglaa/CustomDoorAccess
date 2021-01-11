# CustomDoorAccess 1.2.4

Config Setting | Value Type | Default Value | Description
--- | --- | --- | ---
is_enabled | Bool | true | Enable or disable CustomDoorAccess.
revoke_all | Bool | false | Allow or disallow revocation of the access to all the other keycards.
scp_access | Bool | false | Allow or disallow SCPs to open doors that you set with scp_access_doors.
access_set | Dictionary | 012: 0 / 173: 1&2 / INTERCOM: 5&7 | Gives access to the door with the item(s) that you set.
scp_access_doors | List | CHECKPOINT_ENT / CHECKPOINT_LCZ_A / CHECKPOINT_LCZ_B | List of the doors that SCPs can open. Only works if door is edited on the access_set config.
scp079_bypass | Bool | true | Allow or disallow SCP-079 bypass.

```
Example:
You want the NUKE_SURFACE door to only be opened with a O5 Keycard and a Chaos Card => set revoke_all to true and add NUKE_SURFACE to access_set with the following ids 10&11 (USE & separator to add multiple items)

revoke_all: true
access_set: 
    NUKE_SURFACE: 10&11

It’s worth noting that revoke_all only revokes access to the default cards to the doors which you added with access_set.

If you need help with the configurations, contact me on Discord @Faety#0060.
```

**Some doors need revoke_all to work because they don’t need keycards by default!**
```
012_BOTTOM,012_LOCKER,173_ARMORY,173_CONNECTOR,ESCAPE_PRIMARY,ESCAPE_SECONDARY,GR18,HID_LEFT,HID_RIGHT,LCZ_WC,SERVERS_BOTTOM,SURFACE_GATE
```

### Doors List

Doors ID | Room/Door
--- | ---
012 | SCP-012 FIRST CONTAINEMENT DOOR
012_BOTTOM | SCP-012 CONTAINEMENT DOOR
012_LOCKER | SCP-012 LOCKER DOOR
049_ARMORY | SCP-049 ARMORY DOOR
079_FIRST | SCP-079 FIRST GATE
079_SECOND | SCP-079 SECOND GATE
096 | SCP-096 CONTAINEMENT DOOR
106_BOTTOM | SCP-106 BOTTOM DOOR
106_PRIMARY | SCP-106 LEFT DOOR
106_SECONDARY | SCP-106 RIGHT DOOR
173_ARMORY | SCP-173 ARMORY DOOR
173_BOTTOM | SCP-173 FIRST DOOR (like me)
173_CONNECTOR | SCP-173 SECOND DOOR
173_GATE | SCP-173 CONTAINEMENT GATE
914 | SCP-914 CONTAINEMENT GATE
CHECKPOINT_EZ_HCZ | ENTRANCE CHECKPOINT
CHECKPOINT_LCZ_A | LCZ A CHECKPOINT
CHECKPOINT_LCZ_B | LCZ B CHECKPOINT
ESCAPE_PRIMARY | FIRST DOOR NEAR THE MTF SPAWN
ESCAPE_SECONDARY | SECOND DOOR NEAR THE SPAWN
GATE_A | GATE A
GATE_B | GATE B
GR18 | DOOR FROM EMPTY CONTAINEMENT ROOM IN LCZ
HCZ_ARMORY | HCZ ARMORY DOOR
HID | HID DOOR
HID_LEFT | HID LEFT DOOR
HID_RIGHT | HID RIGHT DOOR
INTERCOM | INTERCOM DOOR
LCZ_ARMORY | LCZ ARMORY DOOR
LCZ_CAFE | DOOR FROM THE TABLES ROOMS IN LCZ
LCZ_WC | TOILETS DOOR OR FOR AMERICANS WC
NUKE_ARMORY | NUKE ARMORY DOOR
SERVERS_BOTTOM | DOOR FROM THE SERVERS ROOM (like me)
SURFACE_GATE | DOOR BETWEEN MTF/CHAOS
SURFACE_NUKE | DOOR FROM THE NUKE AT THE SURFACE

### Items List

Items ID | Description
--- | ---
-1 | No item or error
0 | Janitor Keycard
1 | Scientist Keycard
2 | Major Scientist Keycard
3 | Zone Manager Keycard
4 | Guard Keycard
5 | Senior Guard Keycard
6 | Containment Engineer Keycard
7 | MTF Lieutenant Keycard
8 | MTF Commander Keycard
9 | Facility Manager Keycard
10 | Chaos Card
11 | 05 Card
12 | Radio
13 | Com15 Pistol
14 | Medkit
15 | Flashlight
16 | MicroHID
17 | SCP-500
18 | SCP-207
19 | Weapon Manager Tablet
20 | Epsilon-11 Standard Rifle
21 | P-90 
22 | Epsilon ammo
23 | MP7
24 | Logicer
25 | Grenade
26 | Flash Grenade
27 | Detainer
28 | MP7/Logicer ammo
29 | Pistol/P90/USP ammo
30 | USP
31 | Bouncy Ball
32 | SCP-268 
33 | Adrenaline
34 | Painkillers
35 | Coin