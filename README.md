# Week 8 Assignment - Survival Shooter
# Game and Simulation II

## Game Feel Elements Added

Camera Shake 
	- Used an animator, much like your example.

Player Dust Trail 
	- Particle system, and added two lines of code to the 'Move' function inside the PlayerMovement script.

Enemy Flash 
	- Created two functions - 'EnemyFlash' and 'ResetMaterial' - in the EnemyHealth script.

Enemy Hit Stop 
	- Created a TimeManager script with a function called 'SlowTime'. I called that function in the 'Death' function inside EnemyHealth script.

Dramatic Camera Zoom
	- Used animation much like Camera Shake as I created a new Clip called CameraZoom. A trigger called "Dead" is used to play it, and it is called inside the 'Death' function in the PlayerHealth script.

Heartbeat 
	- Couldn't find a good heartbeat sound effect, so I used a beeper sound instead.

Enemy Health Bar
	- The circle under the enemies was done much like your example, but I created an EnemyHealthBar script to update the healthbar.
