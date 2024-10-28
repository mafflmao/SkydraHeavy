# Skydra

Skydra is a set of tools for modifying and extracting assets from the Skylanders games

## Tools

Skydra consists of multiple tools, tied together by the LibSkydra backend, these tools are:
* Skydra: A level editor (I DONT KNOW IF THIS WORKS!)
* SkydraHeavy(Previously SkydraLite): a ripoff of Ard/Cogmonkey's Alchemist

## LibSkydra

The backbone of these tools, it contains definitions for all igObjects of interest along with methods of reading them

## Credits:

* NefariousTechSupport: Created this
* LG-RZ: Massive help, taught me most things about reading the game files, also I referenced his igArchiveLib while creating igArchive.cs 
* AdventureT: Wrote the StreamHelper class originally
* chrrox: reverse engineered edge index compression (implemented in igPS3EdgeGeometry)
* DKDave: helped me find the UVs in the ps3 meshes (implemented in igPS3EdgeGeometry)
* Maff: Added more igObject types, and fixed a few issues.

## Technology

* OpenTK: Rendering in Skydra
