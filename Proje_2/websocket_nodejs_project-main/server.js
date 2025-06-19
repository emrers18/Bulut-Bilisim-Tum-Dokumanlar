const WebSocket = require('ws');
const { MongoClient } = require('mongodb');

// Cloud Run için dinlenecek PORT
const port = process.env.PORT || 3000;
const wss = new WebSocket.Server({ port });

console.log(`WebSocket sunucusu ${port} portunda çalışıyor...`);

// MongoDB bağlantısı
const mongoUrl = "mongodb+srv://canbozkurt4000:Can123.@cluster0.of4r9at.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
const client = new MongoClient(mongoUrl);

async function connectMongo() {
    await client.connect();
    console.log("MongoDB bağlantısı başarılı.");
    return client.db("iotdb").collection("sensors");
}

(async () => {
    const collection = await connectMongo();

    wss.on('connection', (ws) => {
        console.log("Yeni bir client bağlandı.");

        ws.on('message', async (message) => {
            try {
                const data = JSON.parse(message);
                console.log("Veri alındı:", data);

                await collection.insertOne(data);
                console.log("MongoDB'ye kaydedildi.");
            } catch (err) {
                console.error("Hata:", err.message);
            }
        });
    });
})();
