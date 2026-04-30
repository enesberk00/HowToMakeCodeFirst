İlk olark projemize .net versiyonuna uygun olan Entityframework eklentileini kuruyoruz(Nuget Package Manager/Manage Nuget Packages for Solution)
  Microsoft.EntityframeworkCore
  Microsoft.EntityframeworkCore.Tools
  Microsoft.EntityframeworkCore.Design
  Microsoft.EntityframeworkCore.SqServer  "Kullandığınız server uygulamasına uygun olan eklentisine uygun olanı kullanmanız gerekiyor"
  
Daha sonra projemizde kullanıcağımız classlarımızı Models klosörü içinde tanımlıyoruz
Veritabanı için gerekli olan DataContext classımızı oluşturuyoruz
  Burada "public DataContext(DbContextOptions<DataContext> options):base(options)" adında kurucu metodudumuzu oluşturuyoruz
  Ve oluşturduğumuz classları DbSet ile buraya tanımlıyoruz ( Örnek: public DbSet<Musteri> Musteriler { get; set; } )

Sonrasında appsettinngs.json dosyasına girerek burada databasemizi kurduğumuz yerin konumu veriyoruz
  "ConnectionStrings": {"DefaultConnection": "Server=SERVERADI;Database=DATABASEADI;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"}

Bunu da yaptıktan sonra programızın işlevini kontrol ettiğimiz Program.cs dosyasına oluşturduğumuz DataContext ve ConnectionString bilgilerini buraya tanımlıyoruz
  builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);});

Migration işlemine geçmeden önce terminalde dotnet build yazarak projemizi derleryip hata varsa hatalarımızı düzeltiyoruz.(Bu işlemi yapabiliyor olmanız için dotnet altyapısının kurulu olması gerekmektedir)
  Migration yapmak için terminalimnize dotnet ef migrations add InitialCreate(Oluşturcağımız Migration İsmi) yaparak çalıştırıyoruz, işlem başarılı olursa projemizde Migrations adında bir         dosya oluşmuş olması gerekiyor.
  Daha sonra bu işlemleri database işlemek için dotnet ef database update yazıyoruz.

  Bu işlemlerden sonra artık Models dosyasındaki classlarımızın Controllerlarını oluşturmaya başlıyabiliriz.
