# Çakma ERP

**Çakma ERP**, Windows Forms (C#) kullanılarak geliştirilen, temel kontrol tabloları ve üretim süreçlerini yöneten bir kurumsal kaynak planlama (ERP) uygulamasıdır. Bu proje, Kurumsal Bilişim dersi kapsamında final projesi olarak hazırlanmıştır.

## 📺 Tanıtım Videosu

[![YouTube Video - Çakma ERP Tanıtımı](https://img.youtube.com/vi/RsW4mlHSLpY/0.jpg)](https://www.youtube.com/watch?v=RsW4mlHSLpY)

Videoyu izlemek için görsele tıklayın.

## 🚀 Özellikler

**Kontrol Tabloları:**
- Firma, Birim, Dil, Ülke, Şehir
- Malzeme Tipi, Maliyet Merkezi, Ürün Ağacı
- Rota Tipi, İş Merkezi Tipi, Operasyon Tipi

**Ana Ekranlar:**
- Ürün Ağacı
- İş Merkezi
- Materyal
- Rota Yönetimi
- Maliyet Merkezi

## 🛠 Kurulum

### 1. Veritabanını Yükleme
`Database` klasöründe yer alan `KBSERP.bacpac` dosyasını SQL Server Management Studio (SSMS) aracılığıyla içe aktarın (import).

### 2. Sunucu Adını Güncelleme
`CRUD.cs` dosyasının **17. satırında** yer alan SQL Server bağlantı dizesindeki `Server` ismini kendi bilgisayarınızdaki SQL Server ismiyle değiştirin.

