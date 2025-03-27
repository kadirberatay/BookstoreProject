BookStore API

Basit bir kitap satýþ API'sidir. Kitaplar, kategoriler ve sipariþler üzerinde temel CRUD iþlemlerini gerçekleþtirmenizi saðlar.

API Temel Bilgiler
Base URL: https://localhost:44392/api


Book endpoint:

Tüm Kitaplarý Listele: GET /api/books/getall

Baþlýða Göre Arama: GET /api/books/searchbytitle

Kategoriye Göre Kitaplar: GET /api/books/getbooksbycategory

Kitap Detayý: GET /api/books/getbyid

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

Tüm Sipariþleri Getir: GET /api/orders/getall

Sipariþ Detayý: GET /api/orders/getbyid

Sipariþ Ekle: POST /api/orders/add

Sipariþ Sil: POST /api/orders/delete

Sipariþi Güncelle: PUT /api/orders/update

Sipariþ Durumunu Güncelle: PUT /api/orders/updatestatus