using Godot;
using System;

public partial class FmodEventEmitter : Node
{
	Timer maxDurationTimer;
	public bool IsCooldownOver = true;
	private Node gdEmitter;

	public override void _Ready()
	{
		gdEmitter = GetNode("FmodEventEmitter3D");
		maxDurationTimer = new();
		maxDurationTimer.OneShot = true;
		AddChild(maxDurationTimer);
		maxDurationTimer.Timeout += () =>
		{
			IsCooldownOver = true;
			gdEmitter.Call("Stop");
		};
	}
	public override void _ExitTree()
	{
		maxDurationTimer.QueueFree();
	}

	/// <summary>
	/// Plays the currently applied event. An absolute duration can be added with <see cref="Duration"/> 
	/// </summary>
	public virtual void Play()
	{
		if (isTimedEvent && IsCooldownOver)
		{
			IsCooldownOver = false;
			maxDurationTimer.Start();
			gdEmitter.Call("Play");
		}
		else
		{
			gdEmitter.Call("Play");
		}

	}

	public virtual void PlayOneShot()
	{
		gdEmitter.Call("PlayOneShot");
	}
	public virtual void PlayEvent(string eventName)
	{
		SetEventByName(eventName);
		Play();
	}
	public virtual void PlayOneShotEvent(string eventName)
	{
		SetEventByName(eventName);
		PlayOneShot();
	}

	public virtual void Stop()
	{
		gdEmitter.Call("Stop");
	}

	public virtual void SetEventByName(string eventName)
	{
		gdEmitter.Call("SetEventName", eventName);
	}

	//FIELDS

	private bool isTimedEvent = false;
	private float _duration;
	/// <summary>
	/// Sets an absolute duration to the event. Events from the same emitter have to wait the given time to be played again.
	/// </summary>
	public float Duration
	{
		get => _duration = 0;
		set
		{
			if (Math.Abs(_duration - value) > 0.001f)
			{
				_duration = value;
				maxDurationTimer.WaitTime = _duration;
				isTimedEvent = true;
			}
		}
	}
	private float _volume;
	public float Volume
	{
		get => _volume;
		set
		{
			if (Math.Abs(_volume - value) > 0.001f)
			{
				_volume = value;
				gdEmitter.Set("volume", _volume);
			}
		}
	}

	private bool _attached;
	public bool Attached
	{
		get => _attached;
		set
		{
			if (_attached != value)
			{
				_attached = value;
				gdEmitter.Set("attached", _attached);
			}
		}
	}

	private bool _autoplay;
	public bool Autoplay
	{
		get => _autoplay;
		set
		{
			if (_autoplay != value)
			{
				_autoplay = value;
				gdEmitter.Set("autoplay", _autoplay);
			}
		}
	}
	private bool _autoRelease;
	public bool AutoRelease
	{
		get => _autoRelease;
		set
		{
			if (_autoRelease != value)
			{
				_autoRelease = value;
				gdEmitter.Set("auto_release", _autoRelease);
			}
		}
	}

	private bool _allowFadeout;
	public bool AllowFadeout
	{
		get => _allowFadeout;
		set
		{
			if (_allowFadeout != value)
			{
				_allowFadeout = value;
				gdEmitter.Set("allow_fadeout", _allowFadeout);
			}
		}
	}

	private bool _preloadEvent;
	public bool PreloadEvent
	{
		get => _preloadEvent;
		set
		{
			if (_preloadEvent != value)
			{
				_preloadEvent = value;
				gdEmitter.Set("preload_event", _preloadEvent);
			}
		}
	}
}
