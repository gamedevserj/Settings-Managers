# Settings-Managers

This is an asset to help managing audio/video and input settings.

<img src="https://github.com/gamedevserj/Settings-Managers/blob/master/GitImages/InputManager.png" height="256"> <img src="https://github.com/gamedevserj/Settings-Managers/blob/master/GitImages/OptionsMenu.png" height="256">

All managers that need to be singletons should be called in the following way StaticComponent<YourManager>.Instace.YourMethod()

No managers that are used as singletons should be present as components in the scene. The will be created automatically when you first call them.

To add/change input buttons edit the InputButton.cs script and dictionary in InputManager.cs.
