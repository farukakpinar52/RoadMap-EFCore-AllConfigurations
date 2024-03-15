using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

Console.WriteLine("Hello, World!");
ConfigurationDbContext context = new ConfigurationDbContext();







#region 1. EFCore'da neden yapılandıramalara ihtiyaç duyulur ? 
//Varsayılan davranışları yeri geldiğinde özelleştirmek istediğimiz zaman kendi ihtiyacımıza uygun şekilde yapılanmalar oluşturabiliriz.

#endregion

#region 1.A.OnModelCreating Metodu
// Yapılandırılmaların gerçekleştirildiği metotdur. DbContext içerisinde virtual olarak ayarlandığından dolayı bizler bu metodu kendi context sınıfımızın içinde override ederek kullanırız.
//Bu metodu kullanarak model'larımızla ilgili temel yapılandırma davranışlarını Fluent API yazım biçimiyle kullanırız.
#endregion

#region GetEntityTypes() ile Entity'lerin neler olduğunu bilmek ve elde etmek
//onmodelcreating metodu içinde  modelbuilder.Model.GetEntityType() diyerek bize bir koleksiyon yapısı döner ve bu koleksiyonda bizim entity sınıflarımız bulunur.
#endregion

#region  Configurations => Data Annotations - Fluent API
// Tire işaretnin sol tarafındakiler Data Annotation'ları temsil ederken, sağ taraftakiler Fluent API 'deki fonksiyon adlarıdır.

#region A. Table - ToTable
//generate edilecek tablonun adını belirlememizi sağlayan yapılandırma anahtar kelimesidir.
//tablo adları DbSet property'sinden almaktadır bunu özelleştirmek için Table attiribute'unu sınıf üzerinde kullanabiliriz.
#endregion

#region B.Column - HasColumnName, HasColumnType,HasColumnOrder
//Entity sınıflarımızın property'leri tabloların kolonlarına karşılık gelmektedir.
//propperty'lerin adı kolonun adı, tipi ise kolonun tipi olmaktadır.
#endregion

#region C.Foreign Key- HasForeignKey
//ilişkisel tablolarda dependent entity'nin principal entity'e olan ilişkisini belirleyen property yapısıdır.
// FK genelde Default Convention ile rahatlıkla tanımlanabilir ama biz ismi değişik bir FK kullanmak istersen bunu onmodelcreating fonksiyonunda fluent api ile ilişkiyi belirledikten sonra HasForeignKey fonksiyonunu kullanarak belirtiriz.
#endregion

#region D. NotMapped - Ignore
//EFCore, entity sınıfları içersindeki tüm prop'ları default olarak modellenen tabloya kolon şeklinde migrate eder. Bazen entity sınıfları içerisindeki tabloda bir kolonu temsil edilmesini İSTEMEDİĞİMİZ bir prop bulunsun isteyebiliriz, bu prop'u da eşleşmediğini ifade etmek için NotMapped attiribute'ü ile ya da FluentAPI'de Ignore fonksiyonunu kullanabiliriz.
#endregion

#region E. Key -HasKey
//EFCore'da default convention tanımlamasında bir entity'nin içerisindeki ID,Id,EntityId,EntityID kolonu PK olarak otomatik olarak belirlenir. 
//İstediğimiz herhangi bir prop'u default convension dışında Key attiribute'ü ile ya da HasKey fonksiyonu ile PK yapabiliriz.
#endregion

#region F. Timestamp -IsRowVersion
//sonraki derslerde veri tutarlılığı ile ilgili derste detaylı öğreneceğiz
//kısaca : consistency(tutarlılık)
//[TimeStamp] ile işaretlenmiş  Byte[] türünde bir prop oluştur yada oluşan prop'u fluent api ile IsRowVersion() fonksiyonu ile işaretle.
#endregion

#region G. Required - IsRequired
//bir kolonun nullable olmasını istiyorsak Type? şeklinde tipi soru işareti ile belirlenmeli.
//veri girişi zorunlu yani not null olsun istiyorsak [Required] ile ya da IsRequired fonksiyonu ile belirtilebilir.
#endregion

#region H. MaxLenght, StringLenght - HasMaxLenght
// bu şekilde bir verinin kaç karakterli olacağı fluent api ile tanımlanabilir
//[MaxLenght(15)]  <- bu attiribute ile DataAnnotation çözümü
//modelBuilder.Entity<Person>()
//            .Property(p => p.Surname)
//            .HasMaxLength(20);
#endregion

#region I.  Precision - HasPrecision  ile Ondalıklı Veride basamak sınırlamak
//Ondalıklı kısmın kaç basamaklı ve sayının toplam kaç basamaklı olacağını belirlemeizi sağlar
//[Precision(6,2)] <-toplamda 6 basamaklı bir ondalıklı sayı, ondalık kısmı iki basamaklı olacak.
// aşağıda fluent api ile gösterdik
#endregion

#region J. Unicode - IsUnicode
//kolon içerisinde unicode karakterleri kullanılacaksa [Unicode] ya da fluent api ile belirlenir.
#endregion

#region K. Comment - HasComment
//EfCore üzerinden oluşturulmuş olan veritabanı nesneleri üzerinde yorum yapmak istediğimizde kullanabiliiriz.
//örnek olarak person tablosundaki rowVersion prop'una bir açıklama girelim
//[Comment("Bu kolon versiyon kontrolü yapmaktadır.")]
#endregion

#region L. ConcurrencyCheck - IsConcurrencyToken
//Verinin bütünsel olarak tutarlılığını sağlayacak olan bu yapıdan ileride bahsedeceğin.
#endregion

#region M. InverseProperty
//Bazı entity'ler arasında ikili navigation prop tanımlamak gerekebilir
//örneğin her uçuşun bir kalkışnoktası, bir varışnoktası vardır. bu sebeple bağımlı entity üzerinde iki FK iki Nav prop tnaımlanır
//class Flight
//{
//    public int FlightId { get; set; }
//    public int DepartureAirportId { get; set; }
//    public int ArrivalAirportId { get; set; }
//    public string FlightName { get; set; }

//    public Airport DepartureAirport { get; set; }
//    public Airport ArrivalAirport { get; set; }


//}

//public class Airport
//{
//    public int AirportId { get; set; }
//    public string Name { get; set; }
//    [InverseProperty(nameof(Flight.DepartureAirport))]
//    public virtual ICollection<Flight> DepartingFlights { get; set; }
//    [InverseProperty(nameof(Flight.ArrivalAirport))]

//    public virtual ICollection<Flight> ArrivingFlights { get; set; }

//}
#endregion










#endregion


#region Configurations | Fluent API

#region 1. Composite Key : Bir tabloda birden fazla kolonun kümülatif olarak PK olması
// Genelde çoka çoka ilişkilerde ara bağlayıcı tabloda composite key kullanılır.
#endregion

#region 2. HasDefaultSchema ile veritabanındaki şema adının değiştirilmesi
//veritabanındaki default olan dbo şemasını ezip kendi belirlediğimiz isim ile oluşturabiliriz.
//modelBuilder.HasDefaultSchema("ABC");   ile artık tablolarımızın başında ABC.Persons şeklinde tablo adları belirlenir
#endregion

#region 3.PROPERTY ile kolonlara default value girilmesi

#region 3.1. HasDefaultValue
//Bir tabloda bir kolona hasDefaultValue ile değer atanırsa o kolona veri girilmezse o default değer atanmış olacaktır.
//modelBuilder.Entity<Person>()
//            .Property(p => p.Salary)
//            .HasDefaultValue(100);
#endregion

#region 3.2. HasDefaultValueSql
//Default olarak alınacak değer bir sql sorgusu ile verilecekse bu fonksiyon kullanılır
//modelBuilder.Entity<Person>()
//          .Property(p => p.CreatedDate)
//          .HasDefaultValueSql("GetDate()");
#endregion

#region 3.3. HasField  : gelen veriyi prop üzerinden değil de field üzerinden kullanmak
//Backing Field özelliğini kullanmamızı sağlayan bir yapılandırmadır.
//ilgili entity sınıfında bir field tanımlanır ve ilişkili property 'nin get set özelliklerinde field ataması yapılır
//modelBuilder.Entity<Person>()
//    .Property(p => p.Name)
//    .HasField(nameof(Person._name));
#endregion
#endregion

#region 4. HasComputedColumnSql : Hesaplanmış kolonlar
//veri girişi yapılmaımş bir kolonun diğer kolonlar üzerinden hesaplanmış bir veriye sahip olması
//modelBuilder.Entity<Person>()
//    .Property(p => p.ComputedColumn)
//    .HasComputedColumnSql("[Prim]+[Salary]");
#endregion

#region 5. HasConstraintName : Kendi arzumuza göre bir constraint'e (pk , fk, index, view v.s.) isimlendirmek
//default isim yerine özelleştirdiğimiz bir kalıp isim kullanmak için bunu yapabiliriz
//ÇOK MU LAZIM ? DEĞİL !

#endregion
#region 6.HasData : Seed Data'ların veritabanına yerleştirilmesi
//Hazır verileri migration aşamasında veritabanına göndermek için kullanırız
//detayın ileriki derslerde gireceğiz
#endregion

#region 7. HasDiscriminator : Kalıtım alınmış entity sınıfları için Table Per Hierarchy yaklaşımında discriminator kullanımı
//kalıtıma sahip entity sınıfları için bu yaklaşım otomatik olarak oluşturulur
//kalıtım ilişkisi içindeki tüm entity sınıflarını tek bir tabloda Discriminator ayırıcı kolonu ile oluşturur
//Discriminator kolonuna özel bir adı fluent api ile verebiliriz

//modelBuilder.Entity<BaseEntity>()
//            .HasDiscriminator<string>("Ayırıcı")
//            .HasValue<Derived1>("Kalıtım1")  <-kalıtım sınıfının ayırıcı kolonundaki adı
//            .HasValue<Derived2>("Kalıtım2");  <-kalıtım sınıfının ayırıcı kolonundaki adı

//veri tabanına verileri ekleyerek tablonun son halini gözlemleyebiliriz
//Derived1 derived1 = new Derived1 { BaseProp = "Selam", Derived1Prop = "isme dikkat" };
//Derived2 derived2 = new Derived2 { BaseProp = "aaa", Derived2Prop = "bbb" };

//await context.AddAsync(derived1);
//await context.AddAsync(derived2);

//await context.SaveChangesAsync();

#endregion
#region 8. HasNoKey : Bir tabloda primary key 'in bulunmamasını istemek
//normalde her entitynin bir PK sı olmalıdır 
//eğer PK olmasın istiyorsak bu fonksiyonu kullanmalıyız

//modelBuilder.Entity<PKsızSınıf>()
//            .HasNoKey();
#endregion

#region 9. HasIndex  : Bir tabloda bir kolona index vererek sorgulama kabiliyetini hızlandırmak
//sonraki derslerde detaylı bir inceleme olacak
//HasIndex fluent api'deki fonksiyonudur
#endregion

#region HasQueryFilter : GlobalQueryFilter dersinin yapılandırılmasıdır.
//biz bir entity 'nin listesini çekerken gizli bir where şartı koyar 
//context.Persons.ToList() dediğimizde o aşağıda yazan durumlara göre şartlar oluşturur.
//Bir entity sorgulanırken örneğin biz personelleri getirmek istiyoruz o halde halihazırda çalışan personelleri getirmek isteyebiliriz bunun için Active özelliği 1 olanları getirmek için 
//modelbuilder.Entity<Person>()
//              .HasQueryFilter(p=>p.Active == 1);

//ya da bu yıl işe başlamış olanları
//modelbuilder.Entity<Person>()
//              .HasQueryFilter(p=>p.CreatedDate.Year == DateTime.Now.Year);
#endregion


#endregion










class ConfigurationDbContext : DbContext
{
    DbSet<Person> Persons { get; set; }
    DbSet<Departman> Departmans { get; set; }

    DbSet<BaseEntity> BaseEntitys { get; set; }

    DbSet<Derived1> Derived1s { get; set; }

    DbSet<Derived2> Derived2s { get; set; }

    DbSet<PKsızSınıf> PKsızSınıfs { get; set; }




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-P7KA77K\\SQLEXPRESS;Database=EFConfigurationDB;User Id=sa;Password=1234; ;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region GetEntityTypes  - migration basılırken PMC ekranında entity sınıflarının adını görürüz.
        //ıenumerable<ımutableentitytype> entities = modelbuilder.model.getentitytypes();
        //foreach (var entity in entities)
        //{
        //    console.writeline(entity.name);
        //}
        #endregion
        #region ToTable ile tablo adlarını değiştirerek kaydetmek
        //modelBuilder.Entity<Person>()
        //    .ToTable("Ahhhmeeett");
        #endregion
        #region HasColumnName - HasCoulmnType - HasCoulmnOrder
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Salary)
        //    .HasColumnName("Maaş")  <-- Burada adını belirledik
        //    .HasColumnType("int");  <--Burada tipi belirledik
        //    .HasColumnOrder  ile de veritabanındaki sırasını belirleriz.
        #endregion
        #region İstenilen property için Foreign Key'i belirtmek
        //Eğer bir tablodaki prop'u kendi isteğimize göre isimlendirip onu da FK yapmak istersek bunu burada fluent api ile önce ilişkiyi belirtip daha sonra bu ilişkideki FK'yı belirtmeliyiz. Dilersek o FK'nın veritabanındaki ismini de belirleyebiliyoruz.
        //modelBuilder.Entity<Person>()
        //    .HasOne(p => p.Departman)
        //    .WithMany(d => d.Personlar)
        //    .HasForeignKey(p => p.BenimIcınFKBudur)
        //    .HasConstraintName("Benim_Icın_Fk_Adı_Sectim");

        #endregion
        #region Bir prop'un tabloda kolon olarak işlenmemesi için Ignore fonksiyonunun kullanılması
        //modelBuilder.Entity<Person>()
        //    .Ignore(p => p.NotMappedPropumuz);
        #endregion
        #region HasKey ile PK belirleme
        //modelBuilder.Entity<Person>()
        //    .HasKey(p => p.Id);
        #endregion
        #region IsRowVersion ile veri tutarlılığını bildirme
        //modelbuilder.entity<person>()
        //    .property(p => p.rowversion)
        //    .ısrowversion();
        #endregion
        #region Zorunlu veri girilmesi gereken property'yi bildirmek IsRequired()
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Surname)
        //    .IsRequired(true)
        //    .HasMaxLength(20); // <- Burada veri girişinin 20 satır olacağını söylüyoruz.

        #endregion
        #region HasPrecision ile ondalıklı sayılarda basamak sayısını bildirmek
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Salary)
        //    .HasPrecision(7,2);
        #endregion
        #region IsUnicode ile özel karakterlerin kullanılmasını sağlamaak.
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Name)
        //    .IsUnicode(true);
        #endregion
        #region HasComment ile yorum eklemek
        //modelBuilder.Entity<Person>()
        //    .HasComment("Bu tablo şu işe yarıyor")
        //    .Property(p => p.Name)
        //    .HasComment("Bu kolon kişilerin adını alır");
        #endregion
        #region IsConcurrencyToken eşzamanlılık / tutarlılık
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.ConcurrencyCheckColumn)
        //    .IsConcurrencyToken();
        #endregion
        #region Composite Key
        //modelBuilder.Entity<Person>()
        //    //.HasKey("Id","Id2")
        //    .HasKey(p => new { p.Id, p.Id2 });

        #endregion
        #region HasDefaultSchema
        //modelBuilder.HasDefaultSchema("ABC");   
        #endregion
        #region PROPERTY ile default value atamak
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Salary)
        //    .HasDefaultValue(100);

        //modelBuilder.Entity<Person>()
        //    .Property(p => p.CreatedDate)
        //    .HasDefaultValueSql("GetDate()");

        //backing field özelliğini kullanmak
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Name)
        //    .HasField(nameof(Person._name));

        #endregion
        #region HasComputedColumnSql
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.ComputedColumn)
        //    .HasComputedColumnSql("[Prim]+[Salary]");
        #endregion
        #region HasConstraintName ile constraint adlarını belirlemek
        //modelBuilder.Entity<Person>()
        //    .HasOne(p => p.Departman)
        //    .WithMany(d => d.Personlar)
        //    .HasForeignKey(p => p.DepartmanId)
        //    .HasConstraintName("FK_Per_Dep_");
        #endregion
        #region HasData ile tohum verilerin programa eklenmesi
        //modelBuilder.Entity<Person>()
        //    .HasData(
        //    new Person { Id=5, CreatedDate = new DateTime(), Name="Ali", Midname="", Prim=5,Salary=100, DepartmanId=5, Surname="KK" }
        //    );
        //modelBuilder.Entity<Departman>().HasData(new Departman { Id = 5, DepartmanName = "Insan Kaynaks" });
        #endregion
        #region Discriminator kolonuna özel isim vermek
        //modelBuilder.Entity<BaseEntity>()
        //    .HasDiscriminator<string>("Ayırıcı")
        //    .HasValue<Derived1>("Kalıtım1")
        //    .HasValue<Derived2>("Kalıtım2");
        ////alternatif kullanım
        //modelBuilder.Entity<BaseEntity>()
        //    .HasDiscriminator<int>("Sayısal şekilde Ayırıcı")
        //    .HasValue<Derived1>(1)
        //    .HasValue<Derived2>(2);
        #endregion
        #region HasNoKey
        //modelBuilder.Entity<PKsızSınıf>()
        //    .HasNoKey();
        #endregion
        #region HasIndex
        //modelBuilder.Entity<Person>()
        //    //.HasIndex(p=>p.Name)   //tek kolonu indexlemek
        //    .HasIndex(p => { p.Name ,p.Surname}); //birden çok kolona indexlemek
        #endregion


    }
}
//[Table("Ahmet")]   <-- Bu attiribute ile tablo adı veritabanında Ahmet olarak oluşturulur.
class Person
{
    public int Id { get; set; }
    //public int Id2 { get; set; }
    public int DepartmanId { get; set; }

    //public int BenimIcınFKBudur { get; set; } //public int DepartmanId { get; set; }  <- bu prop yazılmasa bile EFcore shadow prop ile bunu kendi oluşturur.

    //[Column("İsim")]   <-- Bu attiribute ile kolon adı veritabanında İsim olarak oluşturulur.
    public string _name;
    public string Name { get => _name; set => _name=value; }
    public string? Midname { get; set; }//nullable
    //[Required]  ile bu prop'un gerekli olduğunu bildiririz.
    public string Surname { get; set; }
    //[Column("Maaş", Order = 5, TypeName = "float")] <- bu şekilde tipini,sırasını ve adını değiştirebiliriz
    //[Precision(6,2)] <-toplamda 6 basamaklı bir ondalıklı sayı, ondalık kısmı iki basamaklı olacak.
    public float Prim { get; set; }
    public float Salary { get; set; }
    public float? ComputedColumn { get; set; }
    public DateTime CreatedDate { get; set; }
    //public byte[] RowVersion { get; set; }
    public Departman Departman { get; set; }
    //[NotMapped] ile görmezden geleniecek prop olduğunu belirtmiş oluruz.
    public int NotMappedPropumuz { get; set; }

    //[ConcurrencyCheck]
    public int ConcurrencyCheckColumn { get; set; }

}
class Departman
{
    public int Id { get; set; }
    public string DepartmanName { get; set; }

    public ICollection<Person> Personlar { get; set; }
}

class BaseEntity
{
    public int Id { get; set; }
    public string BaseProp { get; set; }
}
class Derived1 : BaseEntity
{
    public string Derived1Prop { get; set; }
}

class Derived2 : BaseEntity
{
    public string Derived2Prop { get; set; }
}

class PKsızSınıf
{
    public string Name { get; set; }

    public string SurName { get; set; }


}

