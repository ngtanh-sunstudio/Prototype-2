# Prototype 2

A Unity Learn Junior Programmer project where the player moves around a play area and fires food at incoming animals.

## What I Learned

### [Lesson 2.1 - Player Positioning](https://learn.unity.com/pathway/junior-programmer/unit/basic-gameplay/tutorial/lesson-2-1-player-positioning?version=6.3)

**New functionality**

- **The player can move left and right based on the user's left and right key presses:** [PlayerController](Assets/Scripts/PlayerController.cs) reads a two-dimensional action, so this version also supports forward and backward movement.
- **The player will not be able to leave the play area on either side:** [PlayerController](Assets/Scripts/PlayerController.cs) clamps both the X and Z positions.

**New concepts & skills**

- **Adjust object scale:** sized the player, animals, projectiles, and play-area objects for the top-down view.
- **If-statements:** run bounds, collision, health, and hunger logic only when their conditions are true in [PlayerController](Assets/Scripts/PlayerController.cs) and [DetectCollisions](Assets/Scripts/DetectCollisions.cs).
- **Greater/Less than operators:** compare positions, health, and hunger against limits in [PlayerController](Assets/Scripts/PlayerController.cs), [DestroyOutOfBounds](Assets/Scripts/DestroyOutOfBounds.cs), and [DetectCollisions](Assets/Scripts/DetectCollisions.cs).

### [Lesson 2.2 - Food Flight](https://learn.unity.com/pathway/junior-programmer/unit/basic-gameplay/tutorial/lesson-2-2-food-flight?version=6.3)

**New functionality**

- **The player can press the Spacebar to launch a projectile prefab:** [PlayerController](Assets/Scripts/PlayerController.cs) also accepts the left mouse button.
- **Projectiles and animals are removed from the scene if they leave the screen:** [DestroyOutOfBounds](Assets/Scripts/DestroyOutOfBounds.cs) destroys objects that cross the X or Z bounds.

**New concepts & skills**

- **Create Prefabs:** reusable player, projectile, and animal configurations.
- **Override Prefabs:** scene instances can change some values without modifying every instances of the prefab.
- **Test for Key presses:**
  - **Main prototype — new Input System:** [PlayerController](Assets/Scripts/PlayerController.cs) reads enabled `InputAction` values.
  - **Challenge 2 — old Input Manager:** [PlayerControllerX](<Assets/Challenge 2/Scripts/PlayerControllerX.cs>) checks `Input.GetKeyDown(KeyCode.Space)`.
- **Instantiate objects:** [PlayerController](Assets/Scripts/PlayerController.cs)  and [SpawnManager](Assets/Scripts/SpawnManager.cs) uses `Instantiate(gameObject);`.
- **Destroy objects:** [DestroyOutOfBounds](Assets/Scripts/DestroyOutOfBounds.cs) and [DetectCollisions](Assets/Scripts/DetectCollisions.cs) uses `Destroy(gameObject);`.
- **Else-if statements:** the separate Challenge 2 cleanup flow uses mutually exclusive bounds checks in [DestroyOutOfBoundsX](<Assets/Challenge 2/Scripts/DestroyOutOfBoundsX.cs>).

### [Lesson 2.3 - Random Animal Stampede](https://learn.unity.com/pathway/junior-programmer/unit/basic-gameplay/tutorial/lesson-2-3-random-animal-stampede?version=6.3)

**New functionality**

- **The player can press S to spawn an animal:** this behavior was replaced in the next lesson.
- **Animal selection and spawn location are randomized:** [SpawnManager](Assets/Scripts/SpawnManager.cs) selects an array entry and position with `Random.Range`.
- **Camera projection (perspective/orthographic) selected:** the two Prototype 2 scenes use an orthographic camera, while the Challenge 2 scene uses perspective.

**New concepts & skills**

- **Spawn Manager:** [SpawnManager](Assets/Scripts/SpawnManager.cs) centralizes animal selection, timing, position, rotation, and hunger initialization.
- Arrays.
- **Keycodes:** the main prototype does not use legacy `KeyCode` input; only [PlayerControllerX](<Assets/Challenge 2/Scripts/PlayerControllerX.cs>) uses `KeyCode.Space` through the old Input Manager.
- **Random generation:** [SpawnManager](Assets/Scripts/SpawnManager.cs) randomizes animal indices and spawn coordinates.
- Local vs Global variables.
- **Perspective vs Isometric projections:** perspective makes distant objects appear smaller, while an isometric view uses orthographic projection to keep all objects size constant.

### [Lesson 2.4 - Collision Decisions](https://learn.unity.com/pathway/junior-programmer/unit/basic-gameplay/tutorial/lesson-2-4-collision-decisions?version=6.3)

**New functionality**

- **Animals spawn on a timed interval and walk down the screen:** handled by [SpawnManager](Assets/Scripts/SpawnManager.cs) and [MoveForward](Assets/Scripts/MoveForward.cs).
- **When animals get past the player, it triggers a "Game Over" message:** escaped animals are cleaned up, while [PlayerController](Assets/Scripts/PlayerController.cs) triggers Game Over when health reaches zero.
- **If a projectile collides with an animal, both objects are removed:** [DetectCollisions](Assets/Scripts/DetectCollisions.cs) removes the projectile immediately and the animal when fully fed.

**New concepts & skills**

- **Create custom methods/functions:** [SpawnManager](Assets/Scripts/SpawnManager.cs) uses dedicated spawn methods.
- `InvokeRepeating()` to repeat code.
- **Colliders and Triggers:** colliders can block objects from passing through, while triggers allow objects to overlap and notify [DetectCollisions](Assets/Scripts/DetectCollisions.cs) or [PlayerController](Assets/Scripts/PlayerController.cs).
- Override functions.
- Log Debug messages to console (`Debug.Log`).

## Extra

- **Animal hunger and hunger bars:** [SpawnManager](Assets/Scripts/SpawnManager.cs) assigns per-animal hunger, and [DetectCollisions](Assets/Scripts/DetectCollisions.cs) reduces it, scales the bar, and awards score when feeding is complete.
- **Player health and score:** [PlayerController](Assets/Scripts/PlayerController.cs) tracks both values and removes the player when health is exhausted.
- **Aggressive spawning:** [SpawnManager](Assets/Scripts/SpawnManager.cs) can spawn rotated animals from the left and right as well as the front.
- **Input implementation:** the main prototype uses Unity's new Input System package configured in [manifest.json](Packages/manifest.json), while Challenge 2 retains the old Input Manager/legacy Input API; the project permits both backends in [ProjectSettings.asset](ProjectSettings/ProjectSettings.asset).
