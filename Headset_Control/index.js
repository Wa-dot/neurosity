//const { App } = require("@manekinekko/cafy");

const { connect, wait } = require("./utils");
const WebSocket = require('ws')
const wss = new WebSocket.Server({ port: 8080 },()=>{
    console.log('Neurosity server started')
})

const spinner = require("ora")().start();
spinner.info("Navigate to https://console.neurosity.co/ to access training data.");

wss.on('connection', function connection(ws) {
   
   


(async () => {
  const mind = await connect();

  let confirmationThresholdMax = 50;
  let confirmationThreshold = confirmationThresholdMax;
  var handState = false;
  spinner.start(`Main ouverte`);

  mind.kinesis("leftIndexFinger").subscribe(async (intent) => {
    
    if (intent.confidence >= 0.7&&intent.confidence < 0.99) {
      spinner.text = `Command confirming: ${intent.confidence}`;
      handState = true;
      
    }
    await wait(100);
    spinner.text("Main fermée")
    ws.send("close");
    spinner.text = `Command detected. Awaiting confirmation=(conf=${intent.confidence})`;
  });
})();
})
wss.on('listening',()=>{
  console.log('listening on 8080')
})
