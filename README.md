BookStore API

Basit bir kitap sat�� API'sidir. Kitaplar, kategoriler ve sipari�ler �zerinde temel CRUD i�lemlerini ger�ekle�tirmenizi sa�lar.

API Temel Bilgiler
Base URL: https://localhost:44392/api


Book endpoint:

T�m Kitaplar� Listele: GET /api/books/getall

Ba�l��a G�re Arama: GET /api/books/searchbytitle

Kategoriye G�re Kitaplar: GET /api/books/getbooksbycategory

Kitap Detay�: GET /api/books/getbyid

Kitap Ekle: POST /api/books/add

Kitap Sil: POST /api/book/delete

Kitap G�ncelle: /api/book/update


Category endpoint:

T�m Kategorileri Listele: GET /api/categories/getall

Kategoriye g�re ara: GET /api/categories/getbyid

Kategori Ekle: POST /api/categories/add

Kategori Sil: POST /api/categories/delete

Kategori G�ncelle: PUT /api/categories/update


Order endpoint:

T�m Sipari�leri Getir: GET /api/orders/getall

Sipari� Detay�: GET /api/orders/getbyid

Sipari� Ekle: POST /api/orders/add

Sipari� Sil: POST /api/orders/delete

Sipari�i G�ncelle: PUT /api/orders/update

Sipari� Durumunu G�ncelle: PUT /api/orders/updatestatus