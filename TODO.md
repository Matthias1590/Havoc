- Fix namespaces and folder names

- Figure out if we can use something like msbuild to run the mod instead of an entire project

- Maybe move ModLoader class to Havoc.Loader so LoadMods can be internal?
	Maybe more of the logic should be in Havoc.Loader and Havoc could just be only the abstractions for mods to use

- Create some project that generates a dll containing safe hooks (wrappers around monomod hooks)
	Would be ran post-build by Havoc

- Add registries for items, monsters, etc.
	Maybe figure out a way to decompile the assets at runtime, then modify them (add new ones and stuff), and recompile them?
	Or, probably easier, mess with unity's Resources class
