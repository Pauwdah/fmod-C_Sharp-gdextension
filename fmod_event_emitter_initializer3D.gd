extends FmodEventEmitter3D


var isPlaying = false

func Play():
	if isPlaying == false:
		isPlaying = true
		self.play()

func PlayOneShot():
	self.play_one_shot()
		

func Stop():
	self.stop()
	isPlaying = false


func SetEventName(new_event_name: String):
	self.set_event_name(new_event_name)
