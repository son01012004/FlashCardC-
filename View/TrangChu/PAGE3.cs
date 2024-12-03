using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlashCard.View.TrangChu
{
    public partial class PAGE3 : UserControl
    {
        public PAGE3()
        {
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false; // Ẩn viền hàng bên trái
            dataGridView1.BorderStyle = BorderStyle.None; // Loại bỏ đường viền ngoài cùng
        }
    }
}
