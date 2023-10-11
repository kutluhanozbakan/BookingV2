# BookingV2

Booking, Kısacası bir kütüphane yönetim sistemidir. İçerisinde temel olarak yazar ve yazarlara ait kitapların bulunduğu bir yönetim uygulamasıdır.

Kütüphane Yönetim Sistemi

Kütüphane Yönetim Sistemi, DDD (Domain Driven Design) tasarım desenini ve MediatR kütüphanesini kullanarak geliştirilmiş bir kitap yönetim sistemidir. Proje, .NET Core 7 ile yazılmış olup, kullanıcı tarafında JWT ile güvenlik önlemleri alınmıştır.

DDD ve MediatR

DDD, yazılımı domain (alan) ve infrastructure (altyapı) katmanlarına ayıran bir tasarım desenidir. Domain katmanı, uygulamanın iş mantığını içerir ve uygulamanın temel amacını gerçekleştirir. Infrastructure katmanı ise domain katmanına ihtiyaç duyduğu hizmetleri sağlar.

MediatR, DDD'de kullanılan bir mesajlaşma kütüphanesidir. MediatR, domain katmanındaki komutları ve sorguyu infrastructure katmanına ileten bir arabirim görevi görür. Bu sayede, domain katmanı ile infrastructure katmanı arasındaki bağımlılık azaltılmış olur.

JWT

JWT (JSON Web Token), bir kullanıcının kimliğini doğrulamak için kullanılan bir kimlik doğrulama yöntemidir. JWT, bir kullanıcının kimlik bilgilerini şifrelenmiş bir token'da birleştirir. Bu token, API'lere istekte bulunurken kimlik doğrulaması için kullanılır.

HTTP Servisleri

Kitap Yönetim Sistemi, HTTP servislerini kullanarak kitap verilerini senkronize etmek veya dış sistemlerle entegre olmak mümkündür. Bu sayede, kitap verileri diğer sistemlerle kolayca paylaşılabilir.

Query ve Command Handlerlar

Query handlerlar, domain katmanından gelen sorgulara yanıt veren kodlardır. Command handlerlar ise domain katmanından gelen komutları işleyen kodlardır.

Swagger ve Exception Handling

Swagger, API'lerin belgelenmesi ve test edilmesini sağlayan bir araçtır. Exception handling ise uygulamadaki hataların doğru bir şekilde ele alınmasını sağlayan bir süreçtir.

Generic Response ve CRUD operasyonları

Proje içerisinde daha az kod daha çok işlev fikrini benimsemek amacıyla, Yapılan Http işlemleri sonucu dönecek cevapların daha merkezi bir yerden yapılması hedeflenmiştir.

Api EndPoints

![image](https://github.com/kutluhanozbakan/BookingV2/assets/25898716/89a4634d-e9d3-49ea-92dc-1adb93b0356d)
