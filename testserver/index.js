const WebSocket = require('ws')
const wss = new WebSocket.Server({ port: 8080 },()=>{
    console.log('server started')
})
wss.on('connection', function connection(ws) {
   ws.on('message', (data) => {
      console.log('data received \n %o',data)
      if(data=="NG"){
            ws.send("NG_accepted");
      }
      if(data=="bye"){
        ws.send("bye");
  }
      
   })
})
wss.on('listening',()=>{
   console.log('listening on 8080')
})