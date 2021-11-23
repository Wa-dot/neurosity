const WebSocket = require('ws')
const wss = new WebSocket.Server({ port: 8080 },()=>{
    console.log('Neurosity server started')
})
wss.on('connection', function connection(ws) {
   ws.on('message', (data) => {
      console.log('data received')
      if(data=="NG"){
         console.log("Asking for changing gravity  \n")
            ws.send("NG_accepted");
            
      }
      if(data=="bye"){
        console.log("bye  \n")
        ws.send("bye");
  }
      
   })
})
wss.on('listening',()=>{
   console.log('listening on 8080')
})