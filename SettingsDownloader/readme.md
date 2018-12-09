# SettingsDownloader
This is used to host Settings in web server for clients to download & initialize the game with.
With this, you can easily change the settings of the game without building a new game. If the client doesn't have internet access, it will fall back to using the hard-coded settings.

## ServerSettingsProvider
A node application that hosts a web server supplying JSON as string as response on its root. 

### Prerequisites
Node

### Starting
`npm start` is a shorthand for `npm install` (download needed files) & `node index.js` (start the application)
If you already have run `npm install` once, you can use `node index.js` to instantly start the application.


## ClientUsage
The Client (Unity) implementation; global Settings class and methods for overwriting default settings with the downloaded settings.
