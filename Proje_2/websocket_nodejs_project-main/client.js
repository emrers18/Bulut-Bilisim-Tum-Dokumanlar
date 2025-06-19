const WebSocket = require('ws');

const socket = new WebSocket('ws://localhost:3000');

socket.on('open', () => {
    console.log("Sunucuya bağlanıldı.");

    setInterval(() => {
        const data = {
            temperature: (20 + Math.random() * 10).toFixed(2),
            time: new Date().toISOString()
        };
        console.log("Gönderiliyor:", data);
        socket.send(JSON.stringify(data));
    }, 5000); // Her 5 saniyede bir veri gönder
});
