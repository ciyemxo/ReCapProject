using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProcedureSuccessful = "İşlem başarılı";
        public static string CarAdded = "Araba eklendi.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba bilgisi güncellendi.";
        public static string ColorAdded = "Renk eklendi";
        public static string BrandAdded = "Marka eklendi";
        public static string UserAdded = "Kullanıcı eklendi.";


        public static string CarIsNotReturned = "Araba Henüz Teslim edilmedi.";
        public static string BrandNameInvalid = "Marka ismi geçersiz.";
        public static string CarDesriptionInvalid = "Araba açıklaması geçersiz.";

        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kayıt olundu";
        public static string PasswordError = "Parola hatası";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";

        public static string AccessTokenCreated = "Token oluşturuldu";


    }
}
