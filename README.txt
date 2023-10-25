//=======================
//Name: Gabriel Ball
//Date: 09-27-23
//Desc: Rip off of Galaga
//=======================
# CIS267_HW01EndlessRunner_GabrielBall

How to play:
  Controls:
    Left: "A" or left arrow key
    Right: "D" or right arrow key
    Shoot: "Space" or down arrow key
           Press and Hold to continuously fire
    Jump: "W" or up arrow key
  Objective: Survive as long as possible while shooting alien spaceships)
  How the game works: 3 different types of enemies will either fall down towards you or shoot at you.
	If an enemy hits you, you die and the game ends. If an enemy bullet hits you, you lose 50 health.
	You start off with 250 health (so 5 bullets and you are dead). Every 30 seconds, the amount of time
	between each spawn of each enemy type is shortened. Also every 20 seconds, a random collectable will spawn.
  Collectables: There are 3 collectables.
	1) Nuke. Upon collecting the nuke, all enemies and their bullets will be destroyed (100 base points)
	2) Rapid Fire. Upon collecting, your firerate will increase, shooting 12.5 bullets per second (10s)(25 base points)
	3) Time Slow. Upon colelcting, everything will slow down by half. Player's movement speed and firerate double to compensate (10s)(25 base points)
  More: If you let an enemy get past you, you will lose 10% of your score. If you let a player shoot you, you will lose 100 points as well as 50 health.
	You can see not only yours, but also enemies' health bars. Enemies and collectables will spawn in the left, middle, right, or
	somewhere in between of the screen. After 5 minutes, you will have reached "max speed" meaning the time between spawns of
	the enemies will no longer decrease. There will be plenty of enemies on screen by then. The entire game takes place within
	the confines of the 2 grey "poles."
