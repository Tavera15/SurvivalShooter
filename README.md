# Week 10 Assignment - Survival Shooter
# Game and Simulation II

----

Controls

Player 1
Move: WASD Keys
Rotate Left: G
Rotate Right: J
Shoot:: H

Player 2
Move: Arrow Keys
Rotate Left: l
Rotate Right: '
Shoot:: ;

----

Your assignment this week is to add 2-Player, local-multiplayer to the Survival Shooter game (what's a good dungeon crawler without multiplayer?). You can use your version of the project you've been working on, or the original, clean version (look under Week 8) for this assignment.

The multiplayer functionality will be both cooperative and competitive. Players will work together to defeat enemies, and cannot damage each other. However, each player will also have their own score. The game will only end when both players have been defeated, and the winner is the one with the highest score.

Some adjustments you'll need to make:

Controls

Adjust the controls of the game to accommodate both players. Keep in mind that you don't necessarily have to use the mouse to aim and shoot.

Enemies

Enemies should target the player closest to them. Make sure they don't only target Player 1.

UI

Ensure that Player 2's health and score are displayed on screen.

Camera

You have 2 options for the camera view:

A traditional "split-screen" view
A "Smash Bros." style view that scales to show all players
Optional Bonus Challenges:

Add Friendly Fire, where players can damage each other
Make the multiplayer "drop in, drop out" where a second player can join or leave the game at any time (make sure the UI accounts for this)
Add support for up to 4 players
Make the different players have different stats - for example, make Player 2 have less health, but fire faster