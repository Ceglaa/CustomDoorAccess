# CustomDoorAccess 1.2

Config Setting | Value Type | Default Value | Description
--- | --- | --- | ---
cda_access_set | Dictionary | 012: 0 / 173: 1&2 / INTERCOM: 5&7 | Gives access to the door with the item(s) that you set.
cda_revoke_all | Bool | false | Revoke the access to all the others cards or not.
cda_scp_access | Bool | false | Allow SCPs to open doors that you set with cda_scp_access_doors.
cda_scp_access_doors | List | CHECKPOINT_ENT / CHECKPOINT_LCZ_A / CHECKPOINT_LCZ_B | Set the doors that SCPs can open.

```
Thanks to EXILED 2.0 and his authors, the configs are now easier to set.

Exemple:
If you want that the NUKER SURFACE Door only gets open with a O5 Keycard and a Chaos Card, you need to set cda_revoke_all to true and add to access_set NUKE_SURFACE: 10&11

Note that cda_revoke_all only revokes access to the default cards to the doors that you added with cda_scp_access.

If you need help with the configs, contact me on Discord @Faety#0060.
```

**Some doors need cda_revoke_all to work because they don't need keycards by default!**
```
Exemple : ESCAPE
```

### Doors List

Doors ID | Room/Door
--- | ---
012 | SCP-012
012_BOTTOM | SCP-012 CONTAINEMENT DOOR
049_ARMORY | SCP-049 ARMORY DOOR
079_FIRST | SCP-079 FIRST BIG DOOR
079_SECOND | SCP-079 SECOND BIG DOOR
096 | SCP-096 CONTAINEMENT DOOR
106_BOTTOM | SCP-106 BOTTOM DOOR
106_PRIMARY | SCP-106 LEFT DOOR
106_SECONDARY | SCP-106 RIGHT DOOR
173 | SCP-173 CONTAINEMENT DOOR
173_ARMORY | SCP-173 ARMORY
372 | SCP-372 CONTAINEMENT DOOR
914 | SCP-914 CONTAINEMENT DOOR
CHECKPOINT_ENT | ENTRANCE CHECKPOINT
CHECKPOINT_LCZ_A | LCZ A CHECKPOINT
CHECKPOINT_LCZ_B | LCZ B CHECKPOINT
ESCAPE | DOOR NEAR THE MTF SPAWN BEFORE ESCAPE
ESCAPE_INNER | SECOND DOOR NEAR THE SPAWN BEFORE ESCAPE
GATE_A | GATE A DOOR
GATE_B | GATE B DOOR
HCZ_ARMORY | HCZ ARMORY
HID | HID DOOR
HID_LEFT | HID LEFT DOOR
HID_RIGHT | HID RIGHT DOOR
INTERCOM | INTERCOM DOOR
LCZ_ARMORY | LCZ ARMORY DOOR
NUKE_ARMORY | NUKE ARMORY DOOR
NUKE_SURFACE | NUKE TOPSITE DOOR
SURFACE_GATE | DOOR BETWEEN MTF/CHAOS

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
