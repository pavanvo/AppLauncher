using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLauncher.Model {
    public class Settings {
        public int Colomns { get; set; }
        public List<App> Apps { get; set; } = new List<App>();
    }

    public enum PromoType {
        Image,
        Video
    }

    public class Promo {
        public string FilePath { get; set; }
        public PromoType PromoType { get; set; }
    }

    public class App {
        public string Name { get; set; }
        public Promo Promo { get; set; }
        public int Price { get; set; }
        public string ExecPath { get; set; }

        public override string ToString() {
            return $"{Name} [{Price}]";
        }
    }
}
