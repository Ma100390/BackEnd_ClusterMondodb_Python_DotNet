# 📚 MongoBooks API

Applicazione **.NET 8 + MongoDB Replica Set** eseguibile tramite **Docker Compose**.  
L’API consente la gestione di un catalogo di libri, include documentazione **Swagger UI** e un sistema di **seeding automatico** del database.

---

## 🚀 Avvio rapido

### 1. Clona il repository
git clone https://github.com/<tuo-username>/<nome-repo>.git
cd <nome-repo>

  
### 2. Avvia i container entrando nella root
  docker compose up -d --build

### 3. Verifica che i container siano attivi:
docker ps

### 4. Accedi al container principale:
docker exec -it mongodb1 mongosh


### 5. Attendi circa 10 secondi (tempo di avvio del cluster), poi inizializza il replica set:

rs.initiate({
  _id: "rs0",
  members: [
    { _id: 0, host: "mongodb1:27017" },
    { _id: 1, host: "mongodb2:27017" },
    { _id: 2, host: "mongodb3:27017" }
  ]
})

### 6. Controlla lo stato:
rs.status()

### 7. Ora puoi connetterti tramite la stringa di connessione anche su MongoDb compass oppure tramite jupiter per eseguire query oppure collegarsi tramite .net
