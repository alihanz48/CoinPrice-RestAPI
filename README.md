# 💰 CoinPriceAPI

## 🇹🇷 Türkçe Açıklama

### 📄 Proje Hakkında
**CoinPriceAPI**, kripto para birimlerinin fiyatlarını yöneten ve kullanıcı kimlik doğrulaması için **JWT (JSON Web Token)** kullanan bir **.NET 8 Web API** projesidir.  
Proje, **Entity Framework Core** ile geliştirilmiştir, **ORM - LINQ** ve **EF Core** kullanılarak **MySQL** veritabanı üzerinde çalışır ve **Identity** sistemi ile güvenli kullanıcı kaydı / girişi sağlar.

---

### 🧩 Kullanılan Teknolojiler
- ASP.NET Core 8.0  
- Entity Framework Core  
- MySQL  
- ASP.NET Core Identity  
- JWT (JSON Web Token) Authentication  
- LINQ ve EF Dynamic Filtering  
- POSTMAN (API test arayüzü)

---

### ⚙️ Kurulum Adımları

1. **Projeyi klonlayın:**
   ```bash
   git clone https://github.com/alihanz48/CoinPriceAPI.git
   cd CoinPriceAPI
appsettings.json dosyasına kendi veritabanı bağlantı bilgisini ve JWT anahtarını ekleyin:

json
Kodu kopyala
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=coinpriceapi;user=root;password=yourpassword;"
},
"JwtKey": {
  "Key": "supersecretkey1234567890"
}
.NET bağımlılıklarını yükleyin:

bash
Kodu kopyala
dotnet restore
Veritabanı Migration işlemlerini gerçekleştirin:

bash
Kodu kopyala
dotnet ef migrations add --context CoinPriceApiContext
dotnet ef database update --context CoinPriceApiContext
dotnet ef migrations add --context UserIdentityContext
dotnet ef database update --context UserIdentityContext
API'yi başlatın:

bash
Kodu kopyala
dotnet watch run
Tarayıcıdan veya Postman üzerinden test edin:
👉 http://localhost:5269/swagger

💱 Coin İşlemleri
Tüm coin uç noktaları için Authorization: Bearer <token> başlığı gereklidir.

🔹 Tüm Coinleri Listele
bash
Kodu kopyala
GET http://localhost:5269/api/Price/market
🔹 ID ile Coin Getir
bash
Kodu kopyala
GET http://localhost:5269/api/Price/market/3
🔹 Sembol ile Coin Getir
bash
Kodu kopyala
GET http://localhost:5269/api/Price/market/BTC
🔹 Sıralanmış Coinleri Getir
bash
Kodu kopyala
GET http://localhost:5269/api/Price/market/sort?variable=symbol&sortDirection=asc
🔹 Filtrelenmiş Coinleri Getir
bash
Kodu kopyala
GET http://localhost:5269/api/Price/market/filter?variable=price&operatorr=<&rate=1
🔹 Between Sorgusu ile Filtreleme
bash
Kodu kopyala
GET http://localhost:5269/api/Price/market/filter?variable=price&operatorr=between&rate=50&rate2=200
🔹 Id ile Coin Güncelle
bash
Kodu kopyala
PUT http://localhost:5269/api/Price/market/6
🔹 CoinName ile Coin Güncelle
bash
Kodu kopyala
PUT http://localhost:5269/api/Price/market/XRP
🔹 Coin Ekle
bash
Kodu kopyala
POST http://localhost:5269/api/Price/market
🔹 ID ile Coin Sil
bash
Kodu kopyala
DELETE http://localhost:5269/api/Price/market/98
🔹 CoinName ile Coin Sil
bash
Kodu kopyala
DELETE http://localhost:5269/api/Price/market/ICX
🔐 Kullanıcı İşlemleri
🔹 Kullanıcı Kaydı
bash
Kodu kopyala
POST http://localhost:5269/api/User/Identity/register
🔹 Kullanıcı Girişi
bash
Kodu kopyala
POST http://localhost:5269/api/User/Identity/login
👨‍💻 Geliştirici
Alihan Dursun
📧 dursun.alihan@icloud.com
🔗 LinkedIn
💻 GitHub

🇬🇧 English Description
📄 About the Project

CoinPriceAPI is a .NET 8 Web API project designed to manage cryptocurrency prices and handle user authentication using JWT (JSON Web Token).
It is built with Entity Framework Core and works with a MySQL database using ORM, LINQ, and Identity for secure user registration and login.

🧩 Technologies Used

ASP.NET Core 8.0

Entity Framework Core

MySQL

ASP.NET Core Identity

JWT Authentication

LINQ & EF Dynamic Filtering

POSTMAN (API Testing Tool)

⚙️ Setup Steps

Clone the repository:

git clone https://github.com/alihanz48/CoinPriceAPI.git
cd CoinPriceAPI


Edit appsettings.json and add your database connection & JWT key:

"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=coinpriceapi;user=root;password=yourpassword;"
},
"JwtKey": {
  "Key": "supersecretkey1234567890"
}


Install dependencies:

dotnet restore


Apply migrations and update the database:

dotnet ef migrations add --context CoinPriceApiContext
dotnet ef database update --context CoinPriceApiContext
dotnet ef migrations add --context UserIdentityContext
dotnet ef database update --context UserIdentityContext


Run the API:

dotnet watch run


Open in browser or Postman:
👉 http://localhost:5269/swagger

💱 Coin Endpoints

All coin endpoints require Authorization: Bearer <token> header.

Get All Coins
GET http://localhost:5269/api/Price/market

Get Coin by ID
GET http://localhost:5269/api/Price/market/3

Get Coin by Symbol
GET http://localhost:5269/api/Price/market/BTC

Get Sorted Coins
GET http://localhost:5269/api/Price/market/sort?variable=symbol&sortDirection=asc

Filter Coins
GET http://localhost:5269/api/Price/market/filter?variable=price&operatorr=<&rate=1

Filter Between Values
GET http://localhost:5269/api/Price/market/filter?variable=price&operatorr=between&rate=50&rate2=200

Update Coin by ID
PUT http://localhost:5269/api/Price/market/6

Update Coin by Name
PUT http://localhost:5269/api/Price/market/XRP

Add New Coin
POST http://localhost:5269/api/Price/market

Delete Coin by ID
DELETE http://localhost:5269/api/Price/market/98

Delete Coin by Name
DELETE http://localhost:5269/api/Price/market/ICX

🔐 User Endpoints
Register User
POST http://localhost:5269/api/User/Identity/register

Login User
POST http://localhost:5269/api/User/Identity/login

👨‍💻 Developer

Alihan Dursun
📧 dursun.alihan@icloud.com

🔗 LinkedIn

💻 GitHub

⭐ Projeyi beğendiyseniz yıldız vermeyi unutmayın!
⭐ If you like this project, don’t forget to leave a star on GitHub!
