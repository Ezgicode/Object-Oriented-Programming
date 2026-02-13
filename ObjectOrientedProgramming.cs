using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Security.Cryptography;

NESNE TABANLI PROGRAMLAMA

Kodu kompleks dillerden daha kısaltan bir sistemdir.Nesneleri baz alan bir kodlama dilidir.
    Gerçek bir sistem nesnel par.alara ayrılır ve bu nesneler arasında ilişkiler kurulur nesneler kendi aralarında haberleşebilirler.
    Nesne tabanlı programlamada en küçük esas parça nesnedir.
    Nesneler içerisinde veri tutabileceğimiz alanlar içerir biz bunlara field deriz. Nesnelerin field içindeki değerleri işleyebilmesi için kullanıcağımız şeyler fonksiyonlardır.
    Fonksiyonlar ileride metot property indexer tarzı yapılanmalardır.

    NESNE == CLASS

    Class lar tanımlamadır bir classtan çokça nesne üretebiliriz.

Nesne oluşturmak için önce modellememiz gerekir nesne modeli de class ile gerçekleştirilir.
Nesneler referans türlü değerlerdir.Nesneleri tutan değişkenler referans türlü değişkenlerdir.

    STACK                                     
Değer türlü değişkenler ve değerleri tutulur.Referansları tutulur.
Değişkenlere isimleri üzerinden bellekteki stack e erişebiliyoruz.

    HEAP
Sadece nesneler tutulur.
Heap e direkt erişim hakkımız yok o yüzden referans ile erişebiliriz.Stack heap e erişebilir onun üzerinden referans tanımlayıp erişim yapabiliriz.

    1. CLASS 

    Classlarda nesnelerdeki ortak alan tanımları yapılır. Mesela Ad(field) yaşhesapla(metot) bu sınıftaki bütün nesnelerde bunlar vardır ama değerleri değişkenlik gösterebilir.
    Classlar bür türdür yani class a verdiğimiz isim nesnenin türüdür.

    class clasismi
{
    class diğerisim
    {

    }
}
    Sınıf 3 farklı yerde oluşturulabilir.
    1-Namespace içinde
    2-Namespace dışında
    3-Class içerisinde(nested type)

    Bir class tanımlamasında tanımlanan yerde aynı isimde birden fazla class tanımlanamaz.
    Aynı namespace içindeki class lar birbirlerine isimleri üzerinden erişebilirken farklı namespace içinde olan classlar birbirlerine namespace üzerinden erişebilir.


    Bu alttaki classta X ve Y classlarının a ve b y e erişebilmesinin nedeni aynı class içinde olmalarıdır.
    class örnek
{
    int a;
    int b;

    public void x(){
        Console.WriteLine(a+" "+b)
    }
    public void Y(){
        return a * b;
    }

}

OrnekModel w;  #Referans alma eğer referans noktasında herhangi bir nesne referans edilmiyorsa o referans noktası null değere sahiptir.

Referans türlü değişkenler özünde nullable olabilen değişkenlerdir.


2- CLASS MEMBERS

4 farklı şey tanımlayabiliriz.

1-FIELD 
2-METOT
3-PROPERTY
4-INDEXER

Field 
Sadece field larrda default değer atanır.
class MyClass
{
    int a;
}
Burada a değerimiz otomatik olarak 0 dır çünkü field larda eğer değerini belirtmezsek otomatik olarak default değerini alır.


Ama class içinde olmayan bir durum için mesela alttakinde hata verebilir çünkü tanımlı bir değer yok ve bir field olmadığı için de default değer atanmaz.
    int a;
    Console.WriteLine(a);
Yeni nesne oluşturmak:

1-new myclass();
2-myclass m1 = new myclass();
m1.a


Property

Nesne içerisinde özellik sağlar.
Property nin değeri çağrıldığında get tetiklenir bir değer atanıcağında set değeri tetiklenir.
Metottan bir farkı yoktur ama nesne üzerinde değer atamam ve değer okuma işlemlerinde kullanılır.
Metottan tek farkı parametre almıyor get set kullanıyor.
Yazılımcılar nesneler ierisindeki fieldlara direkt erişilmesini istemezler bu yüzden filedları kontrollü bir şekilde
    dışarıya açmak için metot ama özelleşmiş olarak property kullanırız diğer dillerde metot kullanılır.

Bu yüzden kontrollü bir erişim fonksiyon tarzı şeyler yaparız field a direkt erişimi engellemek için ilk olarak orayı private yaparız.
Propertylerin bu işlevine encapsulation denir.

    FULL PROPERTY

   public int Yası { get => yası; set => yası = value; }
En sade property yapılanmasıdır. İçerisinde get ve set blokları tanımlanmalıdır.Bu propertyin set bloğu tanımlanmazsa sadece okunabilir yani read only get bloğu tanımlanmazsa sadece yazılabilir write only olur.

    class secondclass {
    int yası;
    string b;

    //Property hangi türden field ı temsil ediyorsa o türden olmalıdır. Propertyler temsil ettikleri field ların isimlerinin başharfi büyük olucak şekilde isimlendirilir.
    public int Yası
    {
        get
        {
            //Property üzerinden değer talep edildiğinde bu blok tetiklenir yani değer buradan gönderilir.
            return yası - 10;
        }
        set
        {
            yası = value;
        }
    }
    

    Console.WriteLine(secondclass.Yası);//Get tetiklendi
    secondclass.Yası= 22;//Set tetiklendi


    class banka
    {
        int bakiye;

        public int bakiye
        {
            get
            {
                if (bakiye > 0)
                    return bakiye * 10 / 100;
                return 0;
            }
            set
            {
                if (value < 10)
                    bakiye = value;
                else
                    bakiye = value * 95 / 100;
            }
        } 
    }

    PROP

Bir property her ne kadar encapsulation yapsa da fielddaki dataya hiç müdahale etmeden erişilmesini ve veri atanmasını sağlıyorsa bu property e prop denir.
 Prop imzalarda property read only olabilir ama write only olamaz.
 
    public int MyProperty { get; set; }

 Bu yukarıdaki == bu aağıdakine eşittir
        public int yası
    {
        get
        {
            return yası;
        }
        set
        {
            yası= value;
        }
    }


Auto Property Inıtializers 

Bir property nin ilk değerini nesne başladığı gibi verebiliriz
Read only olan proplara hızlıca değer atanabilir.
        class ınsanentity
    {
        public string Adı { get; set; } = "Ezgi";
        public string soyAdı { get; set; } = "Öztürk";
        public int Yası { get; set; } = 23;

    }


ref readonly Return

Bir sınıf içerisindeki field ı referansıyla döndürmemizi sağlayan ve bir yandan da bu değişkenin değerini read only yapan özelliktir.
Bellek optimizasyonunu sağlar.

string adı = "Ezgi öztürk";

    public ref readonly string Adı => ref Adı;


Computed Hesaplanmış Properties

İçerisinde türetilmiş bir bağıntı taşıyan propertydir.

int s1 = 5;
int s2 = 6;
public int topla
    {
        get
        {
            return s1 +s2;
        }
    }

    Expression- Bodied Property

Tanımlanan property de Lambda expression kullanmamızı sağllayan söz dizimidir.
    Sadece read only de kullanılır.
        public string Cinsiyet
    {
        get
        {
            return "Erkek";
        }
    }

    public string Cinsiyet => "Erkek";
    
Init Only Property -Init Accessor

Sadece ilk yaratılış anında propertylerine değer atamaktır.
Runtime gereği değerinin değişmemesi gereken nesneler için önlem alınmaktadır.
Developer açısından süreç esnasında değiştirilmemesi gereken property değerlerinin yanlışlıkla değiştirilmesinin önüne geçmekte ve olası hataları önlemektir.
Ama object initiliazer destekler.

Metot

Nesne üzerinde fieldlarda yahut dışarıdan parametreler eşliğinde gelen değerler üzerinde işlemler yapmamızı sağlayan temel programatik parçalardır.

myclass.X();

Indexer

Nesneye indexer özelliği kazandıran yapı olarak property ile birebir aynı olan elemandır.
get set içerir gönderilen veriyi value keywordüyle yakalar.

myclass[5]= 10;

public int this[int a]
    {
        get
        {
            return a;
        }
        set
        {

        }
    }


CLASS İÇİNDE CLASS

Böyle class içinde class tanımladığımızda MyClass m2 = new MyClass2(); 
olarak tanımlayamayız çünkü bu class içinde bir class yani direkt çağıramayız türü 
class içinde classtir.Yani MyClass.MyClass2 m2 = new MyClass.MyClass2(); object türünde
değişken tanımlayabiliriz.


class MyClass
    {
        int a;

        public class MyClass2
        {

        }
    }


This görevleri

1. sınıfın nesnesini temsil eder

class myclass
    {
        public void x()
        {
            this.x();
        }
    }

2. aynı isimde field ile metot parametrelerini ayırmak için kullanılır


class myclass
    {
        int a;
        public void x(int a)
        {
            this.a;
//nesnenin içindeki member olan a alınır parametre olan değil            
        }
    }


3. bir constructer dan başka bir constructer ı çağırmak için kullanılır


        NESNE KAVRAMI 

Nesne özellikleri içeren taslaktır.O olgunun özelliklerini verilerini içerip işlem yapabilmeni 
   fonksiyon uygulayabilmeni sağlayan sistemdir.

        ezgi nesne yaş boy saç rengi 
nesneler classlara göre olur.

Nesneler complex değerlerdir. Nesneleri modellememizi sağlayan classlar ise complex typelardır.


NESNE ÜRETİMİ

new Type(); //parantez constructer metot

Type x = new Type() // referans noktası tanımladık heap olayları için 

Type x = new()// c# 9.0 ile gelen özellik ilk kısımda type ile zaten belirttiğimiz için gerek kalmıyor


REFERANS NESNE İLİŞKİSİ

RAM in stack bölgesinde tanımlanan ve heap bölgesindeki nesneleri işaretleyen referans eden
değişkenlerdir.

değer heap de referans stack de tutulur.

Referans oluşturma class ,interface , abstract class, record ile olur. 
Referanslar illa bir nesne referans etmek zorunda değiller eğer bir 
referans bir nesne işaretlemiyorsa default olarak null değerini alır.

nesne üzerindeki elemanlara erişmek için referansı kullanıırız m. ...

    myclass m = new myclass()
    m.Myproperty = 10;
class myclass
    {
        public int a;
        public int Myproperty { get; set; }
    }

myclass m2 = null
m2.Myproperty = 20;
// Null olan yani NESNESİ OLMAYAN REFERANSLAR ÜZERİNDEN HERHANGİ BİR
//MEMBERI ÇAĞIRIP İŞLEMEYE ÇALIŞTIĞIMIZDA NULL REFERENCE HATASI ALIRIZ YANİ OLMAZ 
//ÇÜNKÜ BİR NESNESİ YOK REFERANS BUNU HANGİ NESNEYE UYGULASIN???

REFERANSSIZ NESNELER

new myclass(); 
new myclass().Myproperty=10;

İlk tanımlama kısmında erişilir heap de oluştuğu için referans atamazsak erişemeyiz.

        Object initializer ile nesne oluşturma esnasında propertylere ilk değer atama

    myclass m = new myclass()
    {
        a=5,
        Myproperty = 10,
        Myproperty2 = 20,
        Myproperty3 = 30
    }

    //Yukarıdaki object initializers ile atama default değerleri atama sırasında verilen değerler

     myclass m = new myclass() // bu default değerler ile oluşur
     m.Myproperty = 10;//sonradan değer atanır


NESNE KOPYALAMA DAVRANIŞLAR-SHALLOW COPY

static void main ()
    {
        int a = 5;
        int b = a;
    }//bu derin kopyalamadır


1-SHALLOW COPY

Var olan bir nesnenin değerin referansının kopyalanmasıdır.
Shallow copy neticesinde eldeki değer çoğaltılmaz.Sadece birden
fazla referansla işaretlenmiş olur.

Referans türlü değişkenlerin değerlerinin default davranışı shallow copy.

class program
    {
        static void main()
        {
            //Shallow copy
            myclass m1 = new myclass();
            myclass m2 = m1;
            myclass m3 = m2;
            myclass m4 = new myclass();
        }

        static void main2()
        {
            //Shallow copy
            myclass m1 = null;
            myclass m2 = new myclass();
            myclass m3 = m2;
            m1= m3;
        }
    }

2-DEEP COPY

Var olan bir nesne deep copy ile kopyalanıyorsa eğer ilgili nesne miktarı çoğaltılır.
Aynı özelliklere ve değerlere sahip olan bellekte farklı bir nesne daha oluşur.
Klonlama kopyalama ama birine etki eden diğerini etkilemez
Değer türlü değişkenlerde default davranış deep copy.

class Myclass
    {
    public Myclass Clone()
        {
            return(Myclass)this.MemberwiseClone();
            // Membervise bir sınıfın içerisinde o sınıftan türetilmiş olan
            //o anki nesneyi clonelamamızı sağlayan bir fonksiyondur.
        }
    }


    static void main2()
    {
        myclass m2 = new myclass();
        myclass m3 = m2.Clone();
    }

    ENCAPSULATION

Nesnelerimizdeki fieldların kontrollü bir şekilde dışarıya açılmasıdır.

ESKİDEN ENCAPSULATION
class Program
    {
        static void main()
        {
            Myclass m = new Myclass();
            m.ASet(15);
            Console.WriteLine(m.AGet());
        }
    }
class Myclass
{
       
        int a;
        public int AGet()
        {
            return this.a;
        }

        public void ASet(int value)
        {
            this.a = value;
        }

        
}

    //PROPFULL

    private int a;

    public int A
    {
        get { return a; }
        set { a = value; }
    }

    //m.A = 123;
    //Console.WriteLine(m.A);

     INIT ONLY PROPERTIES TANIMLAMA

class Book
    {
        public string Name { get; init; } = "Kutsal isyan";//auto property
        public string Author { get; init; }
        public Book()
        {
            Author = "Yazar ismi";//constructor
        }
    }
    // ya consturctor ya da auto property intiliazier ile alır
    Book book = new Book
    {
        Author = "Yeni kitap",
        Name = "Diğer yazar"
    };

    book.Name = "Burayı değiştiremeyiz artık çünkü init oldu";

        //İnit get olmadan kullanılamaz ve init varken set kullanılamaz.



        10.(15.DK) VİDEO OLAN RECORD VE 11,12,13,14 ,15 VİDEOLARI ATLANDI CONSTRUCTOR SONRAYA  
                                 BIRAKILDI SABRIM KALMADI












                   INHERITANCE KALITIM

        Üretilen nesneler farklı nesnelere özelliklerini aktarabilmekte ve böylece 
        hiyerarşik bir düzenleme yapılabilmektedir.

        Nesnenin bir özelliğini member field fln başka bir nesneye aktarmaya kalıtım denir. 
        Genellenemeyen diğerlerinde olmayan ve sadece o sınıfa ait olan özellikler direkt ilgili sınıfta tanımlanmalıdır.

        C# dilinde hangi yapılar kalıtım alabilirler??

Bu dilde kalıtım sınıflara özel bir niteliktir.Yani bir sınıf sadece başka bir sınıftan kalıtım alabilir.Recordlar da kalıtım alabilmektedir ama sadece kendi aralarında.
Kalıtım alabildikleri tek istisnai sınıf ise Object sınıfıdır. Abstract class interface ve struct ın da kendilerine göre kalıtımsal operasyonları mevcuttur.

: kalıtımda kullanılır.


    using system;

    namespace örnek 
{
    class program
    {
        static void main()
        {
            Opel opelarabam = new Opel();
            opelarabam.degeri;

        }
    }

    class Araba
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public int KM { get; set; }

        class Opel : Araba
        {
            //soldaki sağdakinden kalıtım alır. erişilebilir olmalı mesela private aktarılmaz
            public string degeri { get; set; }
        }

    } 
}


Kalıtım veren sınıfa BASE/PARENT CLASS
Kalıtım alan sınıfa DERIVED/CHILD CLASS

Bir sınıfın sadece bir tane base class ı olur o da direkt aldığı şeydir.Bir class sadece tek bir classtan türer aynı anda birden çok classtan türeyemez.
Bir sınıftan nesne üretimi yapılırken kalıtım aldığı üst sınıflar varsa eğer önce o sınıflardan sırayla nesne türetilir.
    d:c olsun c:b olsun b:a olsun d yi çağırdığımızda ilk a sonra b sonra c sonra d çalışır ve nesneleri oluşur.

    Bu demektir ki ilk olarak base class ın constructor ı tetikleniyor. Haliyle biz nesne üretimi sırasında base class ta üretilecek olan nesnenin istediğimiz 
    constructor u tetikleyebilmeli yahut varsa parametreye bu değerleri verebilmeliyiz.Bunun için base keyword ünü kullanmaktayız.

    static void main()
{
    new D();
    new MyClass2(int a);
    {

    }
}

class Myclass
{
    public MyClass(int a)
    {

    }
    public MyClass(string a)
    {
        
    }
    public MyClass(int a,string b)
    {

    }
}

class MyClass2 : MyClass
{
    public MyClass2() :base()     
    {

    }
    public MyClass2(int a): base(5,"ezgi")
    {

    }

}
//Eğer ki base class in constructor i sadece parametre alan constructor ise derived
//class larda o constructor a bir değer göndermek zorundayız.Bunu da base ile yaparız.
// Eğer ki base class da boş parametreli bir constructor varsa derived classta base ile
// bildirimde bulunmak zorunda değiliz.Çünkü varsayılan olarak kalıtımsal durumda base deki boş parametreli constructor tetiklenir.

//Bir class ın constructorunun yanında:base keywordunu kullanırsak o class ın base classının tüm constructolarını bize getirecektir.
//Base classdan nesne üretimi sırasında hangi constructorun tetikleneceğinni bu şekilde belirleyebiliriz.
//

//this bir sınıftaki constructorlar arasında geçiş yapmamızı sağlar.
//base bir sınıfın base class ının constructolarından hangisinin tetikleneceğini belirlememizi vr
//varsa parametrelerinin değerlerinin derived class dan verilmesini sağlar.

constructor():this(3)
{

}
constructor(int a):this(a,5)//this o nun içindekiler base ana base olanın
{

}
constructor(int a,int b):this(a)
{

}
constructor(string c):this()
{

}


mesela base class da
    int a; 
tanımladık o zaman bu otomatik olarak private dır.yani : base parametresi ile erişemeyiz aynı şekilde 
private olan belirtilen diğer şeylere de erişemeyiz.

int a;
public int MyProperty { get; set; }
public void X()
{
}
private void Y()
{
}
------------------------------------------------

int b;
public int MyProperty2 { get; set; }
private void Z()
{
    this.b = 5;
    this.MyProperty2 = 10;
    base.a = 15;          // bu olmaz
    base.MyProperty = 20;
    base.X();
    base.Y();             // bu olmaz
}

----------------------------------------------------
class A
{
    int a;
    public int b;
    public int MyProperty { get; set; }
}

class B : A
{
    int c;
    public void X()
    {
        this. // c x bu constructor içinde olduğu için geldi a ve b ise kalıtımla
          //  buna aktarıldığı için bu constructor içinde gibi değerlendirilir.
    base.// sadece kalıtımla gelenler gelir 
    MyProperty = 10;// biz bu şekilde direkt de kullanabiliriz çünkü kalıtımla
                    // geldiği için compiler başına otomatik base getirir.
            }
}

OBJECT TÜRÜ

C# dilinde tüm sınıflar object den türemiştir.

İsim Saklama(Name Hiding)// kalıtım durumunda atalardaki herhangi
// bir member ile aynı isimde member a sahip olan nesneler olabilir
// kendi içindeki member ı gönderir yani base dekine hiç erişemeyiz

class A
{
    public int X { get; set; }
}
class B : A
{
    public int X { get; set; }
}

B b = new B();
b.X

    Recordlarda Kalıtım

Recordlar sadece birbirlerinden kalıtım alabilirler.Classlardan kalıtım alamaz ve veremezler.
    Bir record birden fazla recorddan kalıtım alamaz. Temelde class oldukları için objectten türeyip oluşurlar.
    Base ve this keywordleri aynı amaçla kullanılabilmektedir.Name hiding olabilir.

SANAL YAPILAR 

Sanal yapılar bir sınıf içerisinde bildirilmiş olan ve o sınıftan 
türeyen alt sınıflarda da tekrar bildirilebilen yapılardır.

Metot ya da property olabilir.Bir sınıfta bildirilen sanal yapı (Metot ya da property) bu sınıftan türeyen 
    torunlarında ezilebilmekte yani devre dışı bırakılıp yeniden oluşturulabilmektedir.Yani sanal yapılandırılmalarda çakışmadan ziyade üstten gelen bir yapının işlevini iptal edip yeniden yapılandırmaktır.
    bir sanal yapının işlevinin iptal edilip edilmeme durumuna göre tanımlandığı sınıftan mı yoksa bu sınıfın torunlarından mı çağrılacağının belirlenmesi run time da gerçekleşecektir.(geç bağlama late binding)

 Bir member ezilmek isteniyorsa sanal olmak zorundadır.   

    Bir sınıfta sanal yapı oluşturabilmek için ilgili memberın imzasını virtual keywordü ile işaretlemek yeterlidir.

    class MyClass
{
    public void MyMethod()
    {

    }
}

class MyClass
{
    public virtual void MyMethod()
    {

    }
}

//public int MyProperty{get; set;}
//virtual public int MyProperty{get;set;}
  
//Bir classta virtual ile işaretlenerek sanal hale
//getirilmiş bir member(metot ya da property) bu classtan miraz alan torunlarında ezilmek yeniden yazılmak isteniyorsa ilgili classda
//imzası override keywordu işaretlenmiş bir vaziyette tekrardan aynı member oluşturulur.

class myclass
{
    public virtual void Mymethod()
    {

    }
}

class myclass2 : myclass
{
    public override void Mymethod()
    {

    }

}

--------------------------------------------
//virtual olmayan bir şeyi override edemeyiz
static void main()
{
    Terlik t = new Terlik();
    t.Bilgi();

    Kalem k = new Kalem();
    k.Bilgi();
}

class Obje
{
    virtual public void Bilgi()
    {
        Console.WriteLine("Ben bir objeyim");
    }
}

class Terlik:Obje
{
    override public void Bilgi()
    {
        Console.WriteLine("Ben bir terliğim");
    }
}

class Kalem: Obje
{

    public override void Bilgi()
    {
        base.Bilgi();
    }

}

override illa birince dereceden türeyen classlarda olmak zorunda değil alt seviyelerdeki torunlarda da override edilebilir.
    a,b,c,d,e c de b yi (B:a) override edersek d ile e de c de override ettikten sonraki hali aktarılır.


    class Program
{
    static void Main(string[] args)
    {
        Ucgen u = new Ucgen(3, 4);
        Console.WriteLine(u.AlanHesapla());
    }
}
class sekil
{
    public int _boy;
    protected int _en;
    public sekil(int boy, int en)
    {
        _boy = boy;
        _en = en;
    }

   virtual public int AlanHesapla()
    {
        return 0;
    }
}

class Ucgen: sekil
{
    public Ucgen(int boy, int en):base(boy,en)
    {

    }
    public override int AlanHesapla()
    {
        return _boy*_en/2;
    }
}

class Dortgen : sekil
{
    public Dortgen(int boy,int en):base(boy,en) 
    { 

    }
    public override int AlanHesapla()
    {
        return _en*_boy;
    }
}

class Dikdörtgen: sekil
{
    public Dikdörtgen(int boy, int en):base (boy,en)
    {

    }
    public override int AlanHesapla()
    {
        return _en * _boy;       
    }

}

POLİMORFİZM BAŞI 



    -------------------------------------
    -----------------------------------
    -----------------------------------
    ------------------------------------

    .STATİC ÇOK BİÇİMLİLİK


Derleme zamanında sergilenen polimorfizmdir.
Hangi fonksiyonun çağrılacağı derleme zamanında karar verilir.

C# da static poliformizm Metot Overloading bağlantısı.


Metot Overloading= Aynı isimde birbirinden farklı imzalara sahip olan metotların tanımlanmasıdır.
    Ya da bir isme birden fazla farklı türde metot yüklemektir. 
    Haliyle burada bir metodun birden fazla formunun olması poliformizm ken bunlardan kullanılacak olanın derleme zamanında bilinmesi statik poliformizm olarak nitelendirilir.


using System;

namespace polimorfizm
{
    class Program
    {
        static void Main(string[] args)
        {
            Matematik m = new Matematik();
            m.Topla(4, 6);
        }
    }
}


-----------------------------------------------------



namespace polimorfizm
{
    class Matematik
    {
        public long Topla(int s1, int s2)
            => s1 + s2;

        public long Topla(int s1, int s2, int s3)
            => s1 + s2 + s3;

        public long Topla(int s1, int s2, int s3, int s4)
            => s1 + s2 + s3 + s4;
    }
}




    .DİNAMİK ÇOK BİÇİMLİLİK


Dinamik poliformizm çalışma zamanında sergilenen polimorfizmdir. Yani hangi fonksiyonun çalışacağına run time da karar verilir.
C# da dinamik poliformiz denilince Metot Override .
Metot Override: base class’ta virtual olarak işaretlenmiş metotların, derived class’ta override edilerek ezilmesi / yeniden yazılması işlemidir.
Haliyle burada aynı isimde birden fazla forma sahip fonksiyonun olması polimorfizm’ken, bunlardan hangisinin kullanılacağının çalışma zamanında bilinmesi dinamik polimorfizm olarak nitelendirilmektedir.

using System;

namespace polimorfizm
{
    class Arac
    {
        public virtual void Calistir()
        => Console.WriteLine("Araç çalıştı...");
    }
    class Taksi : Arac
    {
        public override void Calistir()
            => Console.WriteLine("Taksi çalıştı...");
    }
}


--------------------------------------------------------
namespace polimorfizm
{
    class Program
    {
        static void Main(string[] args)
        {
            Arac a = new Arac();//derleme
            a.Calistir();//araç çalıştı

            Taksi t = new Taksi();//derleme
            t.Calistir();//taksi çalıştı


            Arac t = new Taksi();//run time
            t.Calistir();//taksi çalıştı

        }
    }
}
override olmasa base çalışır alttaki hiç görünmez name hiding olur

C:B
B:A

A a = new C();// A referansında tutulan c türünden nesne
A a = new B();
A a = new A();

//C c = new C();

Poliformizmde oop bir nesnenin kaltımsal açıdan ataları olan referanslar tarafından işaretlenebilmesidir.
Haliyle ilgili nesne bu ataları olan referans türlerine göre dönüştürülebilmektedir.


class A
{
    public string X { get; set; }
}
class B:A
{
    public string Y { get; set; }
}
class C : A
{
    public string Z { get; set; }
}

// C c = (C)a;

// C c = new C();
// A a = c;
// A a = (A)c;

                     Object – Casting – Polimorfizm(Özet) BU SALAK CAST OLAYLARINI HİÇ ANLAMADIM

object, C#’ta tüm tiplerin atasıdır.

int, string, class’lar → hepsi object olarak tutulabilir.

object o = 123;   // boxing
int x = (int)o;   // unboxing


Boxing: value type → object (heap’e çıkar)
Unboxing: object → value type(cast şart)

Class Casting(A → B → C)
A a = new C();    // upcasting

Otomatik
Güvenli

Polimorfizmin temeli

C c = (C)a;       // downcasting
Cast zorunlu
Yanlış tipse runtime error

Polimorfizm
A a = new C();
a.Metot();

Metot seçimi run-time’da virtual / override şart
Çalışan metot → C’nin metodu

Stack – Heap

Stack: referanslar
Heap: new ile üretilen nesneler
Referans → heap’teki nesneyi gösterir

    Poliformizm Durumlarında Cast As Kullanımı

A a = new C();

C c = (C) a;// A NIN İÇİNDEN C ÇEKME OLAYI
            // KALITSAL OLARAK C A NIN İÇİNDE OLMALI
            // KALITIM OLARAK BAĞLI AMA KENDİSİNDEN ÜST BİR ŞEYİ ÇEKMEYE ÇALIŞIRSAK RUN TIME ERROR VERİR.KALITIM BAĞI YOKSA DİREKT DERLEYİCİ HATASIDIR.

C C = new C();
A a = (A)c;


            AS 

Cast gibi kalıtımsal ilişki olan türler arasında referans dönüşümü yapabilmemizi sağlayan operatördür.

A a = new C();
C c = a as C;
D d = a as D;

Tüm türlere hiyerarşik olarak yapar. Kalıtımsal olmayanlar derleyici hatası verecektir.

Kalıtımsal olarak daha alt hiyerarşide olan nesnelere dönüştürülmeye çalışıldığında referans o nesneyi karşılayamayacağından run time hatası vermeyecek geriye null dönücektir.


           İS

Polimorfizm Durumlarında Tür Dönüşümü – is is operatörü, bir nesnenin gerçek(run-time) türünü kontrol eder.
Kalıtım ilişkisi olan sınıflarda kullanılır.
Sonuç true / false döner.

A a = new C();

Bu durumda nesnenin gerçek türü C’dir.

a is C   // true
a is B   // true
a is A   // true
a is D   // false


📌 Çünkü:
C, B’den B, A’dan türemiştir D ile kalıtım ilişkisi yoktur
D ile kalıtım olsa bile biz C ile oluşturmuşuz.
is, referans tipine bakmaz
Nesnenin heap’teki gerçek tipine bakar
Polimorfizmde güvenli tür kontrolü sağlar

is operatörü, polimorfizmde bir nesnenin hangi türden üretildiğini çalışma zamanında kontrol eder.


    22-25 es geçtim 
    -----------------------------------------------------------------
    ---------------------------------------------------------------------------
    ---------------------------------------------------------------------------
    ---------------------------------------------------------------------------
    ----------------------------------------------------------------------------
    ------------------------------------------------------------------------------
    --------------------------------------------------------------------------------
    --------------------------------------------------------------------------------
    ----------------------------------------------------------------------------------
    ----------------------------------------------------------------------------------

                                    ABSTRACTION-SOYUTLAMA

Abstraction bir sınıfın memberlarından ihtiyaç noktasında alakalı olanları gösterip alakasız olanları göstermemek demektir.
Bir operasyon anında kullanılacak sınıfın sadece o anki operasyona uygun memberlarını getirtebilmek için ilgili memberları temsil edebilecek bir referansa ihtiyacımız olacaktır.
Bunu normal sınıflarla da gerçekleştirebiliriz ama abstract classlar ve interface ler daha uygun bir yapıdır.
Sınıfların birden fazla interface ile implement edilebilmesi ilgili sınıfın birden fazla referansla refere edilebilmesi anlamına gelir bu da interface leri abstraction işlemi için oldukça yaygın kullanılan bir yapı haline getirir.

    25. dk




