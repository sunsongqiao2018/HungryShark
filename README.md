# HungryShark
Game design test in 4 hr

# Main Systems:

Shark's(Player)-
1. basica movement
2. collisions around the border
3.  detect "eat" action by the trigger at the mouth.

Fishes- 
1.random roaming around
2.can be eaten.

Spwaner-
1.that can spwan fishes
2.also records fishes active in the pool.

Main game logic -
1. Assigns the target fish based on current active fishes in the pool
2. Updates game status: game running, game over, replay
3. collaborate with other systems like UI to update score and target fish

UI
1. score board, target fish board and gameover pop up


Possible Improvements:
1. refine player movement and maybe include "dash" action that makes more fun;
2. prey can be "smarter" which will try to escape if shark is near them
3. need to avoid spwaner generate new fish on the same coordinate with shark's that can cause the game to end.
4. code sctructure can be improved for sure
5. also some art updates animations, particles UIs.
6. with this base can also turn into diffrent game play: like "feeding frenzy" or the shark can move up and down by row and other fishes come from the opposite side and you have to eat the right one and avoid the others.
