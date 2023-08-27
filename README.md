# AspNetExternalLogin

Note: 
Fitur ini memerlukan basic MVC dari AspNetIdentity. Apabila belum dibuat bisa follow tutorial berikut: https://www.notion.so/Configure-Identity-Library-for-Login-Register-System-9e58271693694834b78af256bd3a9247

1. Buat Google API terlebih dahulu melalui halaman https://console.cloud.google.com/apis/library
2. Pada navigation menu, pilih APIs & Services, kemudian pilih Enabled APIs & services<img width="960" alt="Dokumentasi 1" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/e8885044-536e-4cbe-ab76-395823b3f4a3">
3. Pilih Create Project <img width="960" alt="Dokumentasi 2" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/57c650dc-56e3-4f2d-973c-9649a18a7362">
4. Beri nama project sesuai kebutuhan. Pada contoh ini akan diberikan nama "AspNetTrialGoogleLogin". Lalu pilih create. <img width="432" alt="Dokumentasi 3" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/3251d05f-db9c-4356-ac75-0cd6b2cdfc5f">
5. Untuk mulai membuat kode authentication, pilih OAuth consent screen pada menu APIs & Services. Pilh external pada User Type, kemudian klik create. <img width="956" alt="Dokumentasi 4" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/bca79aac-7114-4658-bcc9-8ff6bae320a9">
6. <p>Isikan kolom App name dan User support email. Pada kali ini, App name akan diisi "AspLoginWithGoogle" dan email akan diisi email saya sendiri. </p> <img width="673" alt="Dokumentasi 5" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/230aad00-7874-474e-944b-1c20c5236f3d">
7. Isikan email pada kolom Developer contact information sebagai email kontak. Pada contoh ini akan diisi email saya sendiri. Setelah itu klik Save and Continue. <img width="674" alt="Dokumentasi 6" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/a6318f78-0b7e-4f2a-982c-7800434a9661">
8. Pada proses kedua dan ketiga (scopes dan test users), tidak ada data yang perlu ditambahkan, sehingga bisa langsung klik Save and continue.
9. Berikut summary dari data yang telah dibuat. Apabila memerlukan perubahan, bisa klik tombol edit.  <img width="676" alt="Dokumentasi 7" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/829a34e2-9f3e-4a3a-9d21-728cbc7c99f3"> <br> Kemudian klik back to dashboard apabila data telah benar. <img width="676" alt="Dokumentasi 8" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/dedb0206-491f-4743-ab21-57d9b6454928">

10. Setelah kembali ke dashboard, klik pada menu Credentials untuk membuat kode ClientID dan ClientSecret
11. Klik pada menu +Create Credentials, kemudian pilih OAuth Client ID <img width="961" alt="Dokumentasi 9" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/ed949261-5282-44f9-a8ee-9ecf3d885675">
12. <p> Pilih Web Application pada Application Type, dan isikan nama pada kolom name. Dalam contoh ini akan diberikan nama AspGoogleLoginClient </p> <img width="452" alt="Dokumentasi 22" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/6dc6f2da-ffbe-4283-bca8-f5f6d0d87243">
13. <p> Isikan URI localhost project pada bagian Authorized Redirect URL, kemudian tambahkan /signin-google sebagai link redirect untuk login. Kemudian klik Create. </p> <img width="392" alt="Dokumentasi 11" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/09b49dd6-f95d-4349-a9a8-72b4588104bb">
14. <p> Selanjutnya akan muncul kotak dialog yang berisi ClientID dan ClientSecret. Copy - paste kedua kode tersebut agar bisa langsung digunakan pada program. </p> <img width="392" alt="Dokumentasi 12" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/aaa7e204-c079-487c-bf30-cc4494f6acdc">
15. Pada VS Code, tambahkan packages Microsoft.AspNetCore.Authentication.Google melalui project explorer. 
16. Pada Program.cs, tambahkan beberapa baris line code sebagai berikut: 
 ```cs
 //Line code untuk menambahkan external login google
 builder.Services.AddAuthentication().AddGoogle(googleOptions =>
 {
    googleOptions.ClientId = "Isikan code ClientID";
    googleOptions.ClientSecret = "Isikan code ClientSecret";
});

//Line code untuk setting cookie

app.UseCookiePolicy(new CookiePolicyOptions()
{
    MinimumSameSitePolicy = SameSiteMode.Lax
});
```
Note: terdapat metode lainnya yang bisa digunakan untuk mengisi ClientId dan ClientSecret, salah satunya adalah mengisinya pada appsettings.json. Pada percobaan kali ini akan diisikan secara langsung tanpa melalui appsettings.json.
<img width="714" alt="Dokumentasi 13" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/3d7ba543-f14f-43ca-9945-11259963649d"> <br>
17. Buka file Areas > Identity > Pages > Account > ExternalLogin.cshtml.cs kemudian masukan property tambahan yang diperlukan tabel AspNetUsers apabila ada. Dalam hal ini, terdapat 3 tambahan property yaitu EmployeeId, FirstName, dan LastName. Tambahkan property tersebut pada class InputModel <img width="634" alt="Dokumentasi 14" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/c8e77a1f-6a98-4c36-b160-2ec7d07c7697"> <br> Kemudian tambahkan line code pada class OnPostConfirmationAsync: <br> <img width="631" alt="Dokumentasi 15" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/8ecdce68-eb5e-44de-b110-3ad36b4453d3"> <br>
18. Selanjutnya buka file Areas > Identity > Pages > Account > ExternalLogin.cshtml <br>
19. Masukan code cshtml untuk menampilkan form pengisian EmployeeId, FirstName, dan LastName pada halaman web (bisa skip apabila tidak ada properti tambahan pada AspNetUser) <img width="644" alt="Dokumentasi 16" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/5b9ded68-0d36-4014-bd01-5511b01747b1"> <br>
20. Jalankan program dengan perintah dotnet run/dotnet watch
21. Berikut tampilan halaman awal apabila berhasil menambahkan fitur external login <img width="943" alt="Dokumentasi 17" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/265a98b5-25f3-4891-aae4-05d04b4c7853"><br> 
Klik tombol google di bawah label 'Use another service to log in', maka akan otomatis direct menuju google login. Dalam contoh ini akan digunakan email pribadi saya. <br> <img width="345" alt="Dokumentasi 18" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/a332a358-5747-436a-8235-70248b973fb2"> <br>
Apabila berhasil memilih akun google yang akan digunakan, maka akan direct secara otomatis menuju halaman register untuk mebuat akun. Apabila akun telah terdaftar maka akan otomatis menuju ke halaman utama. Masukan properti tambahan lainnya yang diperlukan. <br> <img width="936" alt="Dokumentasi 19" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/da22cdbb-e72c-4b7f-bb28-05e93f85a327"> <br> 
Klik register dan lakukan konfirmasi email. Apabila email telah dikonfirmasi kemudian lakukan proses login ulang menggunakan google. Apabila akun telah terdaftar maka akan otomatis ter-direct menuju halaman utama/index. <br> <img width="958" alt="Dokumentasi 21" src="https://github.com/MarcellinoSP/AspNetExternalLogin/assets/107758652/c25da4d3-9e16-41e6-afb2-b120eef125d8"> <br>
22. Done.
