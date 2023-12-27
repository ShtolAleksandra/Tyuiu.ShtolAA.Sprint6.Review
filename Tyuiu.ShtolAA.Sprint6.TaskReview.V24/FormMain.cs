using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Tyuiu.ShtolAA.Sprint6.TaskReview.V24.Lib;

namespace Tyuiu.ShtolAA.Sprint6.TaskReview.V24
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        DataService ds = new DataService();

        public int[,] valueArray;
        public int countRow;
        public int countColumns;
        public int startX;
        public int endX;
        public int r;
        public int k;
        public int l;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonMatrix_SAA_Click(object sender, EventArgs e)
        {
            try
            {
                countRow = Convert.ToInt32(textBoxStroki_SAA.Text);
                countColumns = Convert.ToInt32(textBoxStolbec_SAA.Text);
                startX = Convert.ToInt32(textBoxGranica1_SAA.Text);
                endX = Convert.ToInt32(textBoxGranica2_SAA.Text);

                Random rnd = new Random();

                valueArray = new int[countRow, countColumns];

                dataGridViewOutPut_SAA.RowCount = valueArray.GetLength(0);
                dataGridViewOutPut_SAA.ColumnCount = valueArray.GetLength(1);


                bool istrap = rnd.Next(0, 2) == 0;

                for (int i = 0; i < countRow; i++)
                {
                    for (int j = 0; j < countColumns; j++)
                    {
                        valueArray[i, j] = rnd.Next(startX, endX);

                        if (istrap)
                        {
                            valueArray[i, j] *= -1;
                        }
                        istrap = !istrap;

                        dataGridViewOutPut_SAA.Rows[i].Cells[j].Value = valueArray[i, j];
                    }
                }
            }
            catch
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonResult_SAA_Click(object sender, EventArgs e)
        {
            try
            {
                int r = Convert.ToInt32(textBoxGranicaR_SAA.Text);
                int k = Convert.ToInt32(textBoxGranicaK_SAA.Text);
                int l = Convert.ToInt32(textBoxGranicaL_SAA.Text);
                int row = dataGridViewOutPut_SAA.Rows.Count;
                int column = dataGridViewOutPut_SAA.Columns.Count;

                if (valueArray != null && l >= 0 && l < countRow)
                {
                    int res = DataService.GetMatrix(valueArray, l,r, k);
                    textBoxRes_SAA.Text = Convert.ToString(res);
                }
                else
                {
                    MessageBox.Show("Матрица не инициализирована или выбрана неверная строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Введены неверные данные для выполнения вычислений", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
