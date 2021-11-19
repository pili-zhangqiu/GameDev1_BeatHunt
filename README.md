# BeatHunt: The Game - Technical Summary
Assignment for the IGGI Module of Game Development 1, led by Dr Jeremy Gow

Final Game Builds: You can find the final MacOS and Windows builds in the /GameBuild folder.
 
### Beat conductor controller

**Main script of interest:** ConductorController.cs

Since our prototype is a rhythm game, we had to make sure that we build a robust global timekeeping system. After some online research, we found the following article which includes examples of how to effectively achieve this, with samples of code and detailed explanations:
https://www.gamedeveloper.com/audio/coding-to-the-beat---under-the-hood-of-a-rhythm-game-in-unity

We repurposed the main script from this source to match the needs of our game. Essentially, the player’s movement, as well as some animation elements in the level and enemies’ action, are tied to the beat of the music through the beat conductor. 


### Player

**Main script of interest:** PlayerController.cs

- **Player’s movement to the beat:** The player’s character consisted of a cube, which rolled on its edges in order to move forward/backward and left/right on the tiled floor. This was done in order to provide the player with a feeling of movement; because the cube moves at the beat, the movement could not just consist of moving the cube to the next tile, as agency started to appear confusing for some players. Having a 3D object rolling on a 2.5D game helped solve this issue. To generate this movement, the size of the cube was computed and taken into consideration to set the radius of the rotation of the cube. The rotation itself was set through the Quaternion.Lerp(...) function. More information can be found in the Cube Roll Movement article from Oimo, at: https://b13.app/unity/unity-script-for-roll-a-rectangular-parallelpiped-jp/. The initial mechanic would have the player tap to the tempo in order to move the cube, with some margin of error implemented as well for difficulty adjustment. After initial playtesting though, the feedback was that even this felt quite restrictive for some testers, so we altered the mechanic a little. The second iteration involved continuously pressing the button and having the cube roll to beat. If the player wanted to change the direction of movement, they had to do it on the beat, otherwise it would be registered on the next one. See the core mechanic in an image explanation below.


- **Player’s health:** The player starts at 3HP health and loses 1HP everytime the player enters a trigger-collision with an enemy GameObject. The player can also collect hearts in order to recover health (i.e. 1 hearts equals +1HP). The player’s health is also capped at a minimum of 0 and a maximum of 3.


### Enemies

- **Bouncy Balls:** The initial implementation of the bouncy balls was having 4 of them present in the level, infinitely bouncing around at an increasing speed until the time runs out. In the second iteration the level started with one ball and the speed was constant, but more balls would spawn as the player progressed. Infinite bounciness and selective collision were achieved through a combination of scripting and attaching a physics material with the right values, after testing, to the game object. (Main script of interest: BallBouncer.cs)


- **Ray Swipers - Columns and Rows:** The Ray Swipers are enemies who can strike an entire row or column at a beat. In order to make it easier for the player to avoid being hit by Ray Swipers, a warning sequence of 2 beats was introduced to the game before the enemy strike. (Main script of interest: ColRayEnemyController.cs & RowRayEnemyController)


- **[Discontinued] - Radial Projectiles:** The very first enemy conceived was a ball that would radially fire projectiles. After extensive testing, we realised that our implementation was quite computationally expensive and would have to be discarded. Nevertheless, it proved useful because it led to the idea of having the bouncy balls, which were far simpler, more effective and more unpredictable in the game, resulting in better enemy design overall. (Main script of interest: LaunchProjectiles.cs)


### Enemy Waves

**Main script of interest:** EnemyWaves.cs

The 120 seconds of gameplay consisted of four enemy waves, each with an incremented difficulty. The specific parameters set for each wave are described in the figure below.
