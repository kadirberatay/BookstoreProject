Database Diagram: ![Image](https://github.com/user-attachments/assets/b557aec0-7bfb-4f18-a229-bc8df831c6a3)

Bookstore API

Basit bir kitap satış API'sidir. Kitaplar, kategoriler ve siparişler üzerinde temel CRUD işlemlerini gerçekleştirmenizi sağlar.

API Temel Bilgiler
Base URL: https://localhost:44392/api


Book endpoint:

Tüm Kitapları Listele: GET /api/books/getall

Başlığa Göre Arama: GET /api/books/searchbytitle

Kategoriye Göre Kitaplar: GET /api/books/getbooksbycategory

Kitap Detayı: GET /api/books/getbyid

Kitap Ekle: POST /api/books/add

Kitap Sil: POST /api/book/delete

Kitap Güncelle: /api/book/update


Category endpoint:

Tüm Kategorileri Listele: GET /api/categories/getall

Kategoriye göre ara: GET /api/categories/getbyid

Kategori Ekle: POST /api/categories/add

Kategori Sil: POST /api/categories/delete

Kategori Güncelle: PUT /api/categories/update


Order endpoint:

Tüm Siparişleri Getir: GET /api/orders/getall

Sipariş Detayı: GET /api/orders/getbyid

Sipariş Ekle: POST /api/orders/add

Sipariş Sil: POST /api/orders/delete

Siparişi Güncelle: PUT /api/orders/update

Sipariş Durumunu Güncelle: PUT /api/orders/updatestatus
