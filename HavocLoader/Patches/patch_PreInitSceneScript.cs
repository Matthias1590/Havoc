using Havoc;

internal class patch_PreInitSceneScript : PreInitSceneScript
{
	public extern void orig_Awake();

	public void Awake()
	{
		Initializer.Initialize();

		orig_Awake();
	}
}
