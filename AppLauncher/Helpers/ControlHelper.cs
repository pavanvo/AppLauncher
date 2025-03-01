﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLauncher.Helpers {
    static class ControlHelper {
        /// <summary>
        /// переместить элементам управления на центр
        /// </summary>
        public static void Move2Centr(this Control control) {
            control.Move2HCentr();
            control.Move2VCentr();
        }

        public static void Move2HCentr(this Control control) {
            control.Left = (control.Parent.Width - control.Width) / 2;
        }
        public static void Move2VCentr(this Control control) {
            control.Top = (control.Parent.Height - control.Height) / 2;
        }
    }
}
