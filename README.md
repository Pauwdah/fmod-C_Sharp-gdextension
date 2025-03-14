# C_Sharp-integration-for-fmod-gdextension

> [!Important]
> This is a C# integration made for the [fmod-gdextension](https://github.com/utopia-rise/fmod-gdextension) addon. Please install the addon first.

I made this for a project of and I hope you can take some use out of it too! c: 

## How to setup:
1. Attach the "fmod_event_emitter_initializer.gd" script to the "FmodEventEmitter2D" or "FmodEventEmitter3D" provided by the addon.
2. Create a parent Node for the Emitter and attach the "FmodEventEmitter.cs" script to it.
3. Done! You can now reference the C# Node and its functions how you usually would with any other object!



## How to use:
> [!TIP]
> The C# Emitter does also allow you to set a cooldown by setting its "Duration" field. 
> If "Duration" isn't set, normal behaviour applies. 

#### The C# script contains currently the following... 

### Functions
```cs
Play();                                 
PlayOneShot();
SetEventByName(string eventName);
PlayEvent(string eventName);            //Shorthand for SetEventByName() + Play()
PlayOneShotEvent(string eventName);     //Shorhand for SetEventByName() + PlayOneShot()
Stop();

```
### Fields
```cs
float Duration; 
float Volume;
bool Attached;
bool Autoplay;
bool AutoRelease;
bool AllowFadeout;
bool PreloadEvent;
```

>[!Note]
>Please don't hesitate to report bugs or features requests. 