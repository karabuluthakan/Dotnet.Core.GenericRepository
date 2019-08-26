namespace Dotnet.Core.Common.Contracts
{
    /// <summary>
    /// İş katmanında işlem sonuçlarının işlem kodu için kullanılır.
    /// </summary>
    public enum ResultStatusCode
    {
        /// <summary>
        /// Başarılı
        /// </summary>
        Ok = 200,
        
        Created = 201,
        
        Updated = 204,
        
        Deleted = 204,

        BadRequest = 400,
        
        /// <summary>
        /// Yetki Sorunu
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        /// Yasak
        /// </summary>
        Forbidden = 403,

        /// <summary>
        /// Bulunamadı
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// Sunucu Hatası
        /// </summary>
        InternalServerError = 500,

        /// <summary>
        /// Kayıt Bulunamadı
        /// </summary>
        ExistingItem = 600,

        /// <summary>
        /// Uyarı
        /// </summary>
        Warning = 700,

        /// <summary>
        /// Bilgilendirme
        /// </summary>
        Info = 800
    }
}