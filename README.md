# SepetStokAPI
Bir E-ticaret sitesinin sepet ve stok yönetimi baz alınarak yazılmış , stok ve sepet yönetimi için gerekli bütün metodları barındıran ,
3 katmanlı mimari içeren ASP.NET CORE 3.1 Web API.

DataAccess Katmanının dosya dizininde , (PowerShell , CMD veya Linux Terminali) üzerinde “dotnet ef database update” komutunun çalıştırılması yeterlidir. 
Bu komutun çalışması için DotNet Tool kurulu olmalıdır;

• “dotnet tool install“ => DotNet Tool kurulumu
• “dotnet ef database update” => Db Modellerinin Sql Server üzerinde işlenmesi için gerekli komut

Projenin Db Migrationları içindedir.
Projenin Connection String ‘i Sql server ‘in local db’si için halihazırda set edilmiş haldedir.
Proje Visual Studio üzerinde açıldığında , üzerinde “Swagger” eklentisi kurulu olarak açılacaktır. 
Bu eklenti Web API ‘nin test edilebilmesi için bir arayüz oluşturmakta ve kolay kullanım sağlamaktadır.

Proje 3 Katmanlı Mimari ile geliştirilmiştir. (Entity , DataAccess ve Business Katmanları) 
CORS denetimi kapatılmıştır , Herhangi bir front end frameworkü üzerinden metodlar (Get , Post , Delete vs.) kullanılabilir. 
İki Adet Controller Bulunmaktadır , ProductsBasketController ve StockController.
ProductsBasketController , kullanıcıların sepetlerini yönetebilmek için, StockController ise ,
stok takibini yönetebilmek için kullanılmaktadır.

Proje Stok kontrolü ile çalışmakta olup, Stok eklemeden önce , Sepete ürün eklemeye çalıştığınızda “false“ dönecektir. 
Çünkü kullanıcı id ve ürün id ile birlikte sepete ürün eklemeye çalıştığımızda, sepete eklenen ürün kadar stoktan ürün adedi düşülmektedir.
Eğer sepete eklenmek istenen kadar ürün yoksa , sepete eklenmeyecektir.


DCD
