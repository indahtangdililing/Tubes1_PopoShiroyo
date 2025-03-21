# Tubes1_PopoShiroyo

## IF2211 Strategi Algoritma
Tubes 1 Stima Pemanfaatan Algoritma Greedy dalam pembuatan bot permainan Robocode Tank Royale

Dipersiapkan oleh Kelompok 17 - Popo? Shiroyo!:

| Nama                      | NIM      |
|:-------------------------:|:--------:|
| Wardatul Khoiroh          | 13523001 |
| Indah Novita Tangdililing | 13523047 |
| Kefas Kurnia Jonathan     | 13523113 |
## Penjelasan Singkat Algoritma Greedy
<p align="justify"> Algoritma greedy adalah pendekatan penyelesaian masalah dengan mengambil keputusan lokal tanpa mempertimbangkan langkah kedepannya. Keempat bot telah dirancang dengan pendekatan heuristik yang berbeda sehingga memungkinkan analisis lebih dalam terhadap efektivitas strategi masing-masing. Popo-Bot menggunakan kombinasi dari ketiga strategi dengan gerakan pola spiral. Shi-Bot menggunakan heuristik dengan pergerakan pola zig-zag. Ro-Bot menggunakan strategi greedy menghindari musuh. Terakhir, Yo-Bot menggunakan strategi greedy mengejar bot musuh dan menembaknya secara agresif. Dengan menerapkan strategi greedy terhadap pergerakan, greedy terhadap serangan, dan greedy terhadap perolehan poin, bot dapat bertahan lebih lama di arena, menyerang musuh secara agresif, dan mengoptimalkan perolehan skor.</p>

## Requirement Program
## Command/Langkah-Langkah Meng-Compile/Build Program
1. Jalankan GUI Robocode dengan menuliskan:
```
java -jar robocode-tankroyale-gui-0.30.0.jar
```
2. Pada menu Config pilih Boot Root Directories, kemudian klik add dan masukkan folder yang berisi bot-bot yang ada.
3. Pada menu Battle pilih Start Battle, maka list bot-bot yang ada akan terdaftar pada Bot Directories (local only).
4. Pilih Bot mana saja yang ingin di-boot ke dalam permainan. Bot yang sukses di-boot akan muncul pada Joined Bots (local/remote).
5. Dari bot yang sudah ada pada Joined Bots, klik add untuk bot-bot yang akan dipertandingkan.
6. Jika sudah, klik Start Battle untuk memulai pertandingan. Selamat menyaksikan!
