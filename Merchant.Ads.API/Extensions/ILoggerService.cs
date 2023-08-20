namespace Merchant.Ads.API.Extensions
{
    public interface ILoggerService
    {
        //4seviyede log alacagımı ifade ediyorum
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogDebug(string message);
    }
    /*Log  bir sistemin çalışması sırasında meydana gelen olayları kaydetmek için kullanılan bir kayıt türüdür
     Hata ayıklama sorun tespiti perf izleme gibi durumları kolaylıkla anlamamıza olanak saglar*/

    /* log formatı olayların ne olduğunu, ne zaman olduğunu, nerede olduğunu ve gerekirse ek detayları içermelidir
     * [2023-08-16 12:34:56] [ERROR] [Service] Error creating user. UserName: ebrar */
}

