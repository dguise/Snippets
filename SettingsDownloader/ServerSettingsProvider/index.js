var express = require("express");
var settings = require("./settings.json");

const app = express();
const port = process.env.port || 3000;

app.get('/', (req, res) => {
  console.log(JSON.stringify(settings));
  res.send(JSON.stringify(settings));
});  

app.listen(port, () => 
{
  console.log(`Settings provider listening on port ${port}!`);
});