# DapperWebAPI

Bu proje basit CustomerAPI, .NET Core Web API, Dapper, MediatR, CQRS ve JSON serialize/deserialize işlemleri kullanılarak geliştirilmiştir.

## Gereksinimler

- **SQL Server** (SQL Server Express, Developer Edition veya benzeri)
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) veya daha üstü
- Visual Studio veya Visual Studio Code

## 1. SQL Server Ayarları

### A. Veritabanını Oluşturun
SQL Server Management Studio (SSMS) veya sqlcmd kullanarak, projede kullanılacak veritabanını (örneğin, `YourDatabase`) oluşturun.

Örnek SSMS:
1. SSMS ile SQL Server'a bağlanın.
2. "New Database" seçeneğini kullanarak `YourDatabase` adlı bir veritabanı oluşturun.

### B. Stored Procedure Scriptlerini Çalıştırın
Projede, `Stored_Procedures_Scripts` adlı klasörde SQL script dosyalarınız bulunmaktadır. Bu dosyalar tablo oluşturma, stored procedure (örneğin, `usp_InsertCustomerJson`, `usp_GetCustomersJson`, vb.) tanımlamalarını içerir.

- **Adım 1:** SSMS'de `YourDatabase` veritabanı context'ini seçin.
- **Adım 2:** `01_CreateTables.sql` dosyasını açıp çalıştırın.
- **Adım 3:** `02_CreateStoredProcedures.sql` dosyasını açıp çalıştırın.

Bu scriptler, veritabanınızda gerekli tabloları ve stored procedure'leri oluşturacaktır.

## 2. Uygulama Ayarları

### A. appsettings.json
`DapperWebAPI.Api` projesi içindeki `appsettings.json` dosyasında, SQL Server'a bağlantı dizenizi güncelleyin. Örnek:

```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=YourDatabase;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"
  }
```
Dikkat:

Server kısmında instance adınız (örneğin, localhost\\SQLEXPRESS) doğru girilmeli.

Gerekirse TrustServerCertificate=True; ekleyin.

## 2. Uygulama Çalıştırma
Visual Studio veya VS Code İle
Projeyi Visual Studio/VS Code ile açın.

DapperWebAPI.Api projesini başlangıç projesi olarak ayarlayın.

Uygulamayı çalıştırın (F5 veya dotnet run komutuyla).

Komut Satırı İle Çalıştırma
Terminal veya Komut İstemcisine gidin ve proje kök dizininde aşağıdaki komutu çalıştırın:

```bash
  dotnet run --project DapperWebAPI.Api
```
Uygulama, default olarak belirttiğiniz bağlantı dizesine göre SQL Server'a bağlanacak ve API endpointleri (örn. /api/customer) üzerinden CRUD işlemlerini gerçekleştirecektir.

4. API Testi
Swagger UI:
Uygulama başlatıldıktan sonra, tarayıcınızda http://localhost:8088/swagger adresine giderek Swagger UI üzerinden API endpointlerini test edebilirsiniz.

Postman veya benzeri araçlarla:
Oluşturma, listeleme, güncelleme ve silme endpointlerini test edebilirsiniz.
