# Week 9 Assignment - Survival Shooter
# Game and Simulation II

Using the Game Maker's Toolkit video, and the SpelunkyGen website as guides, you are to turn your Survival Shooter game into a procedurally-generated (sort of) dungeon crawler.

You'll set this up similarly to how Spelunky works - by generating a "solution path", then filling the rooms (ignore the "snake pit" concept).

This assignment is probably best divided into 3 steps:

Generating the solution path (70%): My advice here is to build a 2-dimensional array, and first fill that in with the appropriate room types. To test this, you can use my already existing "CreateRoom" function. This takes 3 integer values - row, column, and room type - to place an instance of a room at a given position in the grid.

NOTE: One change I've made from the guide is that I have a 'type 4' room - one that's open on all sides. In the guide, they consider this combination a 'type 2' room.

Adding the side rooms (20%):
For the side rooms (which aren't part of the solution path, and are not guaranteed to have any entrances/exists, you'll want to have, at the very least, an option to spawn a '0' room, with no exits. You should balance this though, as a map with only a linear path would be boring!

Blocking the corners (10%): Once you've gotten the solution path and side rooms working correctly, ensure that the player can't leave the map through the corner rooms. For instance, ensure that the top left corner room doesn't have an open path left or above.

Next week we'll be going further with this project by adding a loot and inventory system!