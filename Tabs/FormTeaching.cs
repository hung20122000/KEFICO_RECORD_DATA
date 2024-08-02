using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanHungHa.Tabs
{
    public partial class FormTeaching : MaterialForm
    {
        private static FormTeaching _instance;
        private static readonly object _lock = new object();
        public static FormTeaching GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {

                    if (_instance == null)
                    {
                        _instance = new FormTeaching();
                    }
                }
            }
            return _instance;
        }
        public FormTeaching()
        {
            InitializeComponent();
        }
    }
}
