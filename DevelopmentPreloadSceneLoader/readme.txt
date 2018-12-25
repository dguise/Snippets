## Description
The [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] is an attribute that makes sure this method when the game starts. 
Here we use it to start the preload scene.

## Prerequisites
That the first scene in build index is a preloading scene where you load all neccesary assets used in future scenes. 
(For effiency/synergy: that the preload scene uses the AnykeyNextScene behaviour, using `RuntimeInitializer.startedScene`)
