using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLauncher.Controls {
    public class TableLayoutPanelDoubleBuffered : System.Windows.Forms.TableLayoutPanel {
        public TableLayoutPanelDoubleBuffered()
            : base() {
            BackColor = System.Drawing.Color.Transparent;
            this.DoubleBuffered = true;
        }
    }

}
