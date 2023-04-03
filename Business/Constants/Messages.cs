using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded               = "Ürün eklendi";
        public static string CarNameInvalid         = "Ürün ismi geçersiz";
        public static string MaintenanceTime        = "Sistem bakımda";
        public static string CarsListed             = "Ürünler listelendi";
        public static string CarRentingDenied       = "Araç şu anda kullanım halindedir";
        public static string CarImageLimitExceeded  = "Araç fotoğrafı limiti aşıldı";
        public static string CarImageAdded          = "Araç Eklendi";

        public static string CarImageDeleted { get; internal set; }
        public static string CarImageUpdated { get; internal set; }
    }
}
