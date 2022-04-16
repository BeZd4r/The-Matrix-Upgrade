using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace The_Matrix_Upgrade
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int row, column,skip, o;
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Size_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!int.TryParse(e.Text,out o))
            {
                e.Handled = true;
            }
        }
        private void Transform_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MatrixBefore.Text = "Матрица до умножения: \n";
                MatrixAfter.Text = "Матрица после умножения: \n";
                CreatedVector.Text = "Вектор:\n";
                row = Convert.ToInt32(RowMat.Text);
                column = Convert.ToInt32(ColumnMat.Text);
                if (column * row > 12 || column * row == 0 || column + row < 4)
                {           
                    MessageBox.Show("Недопустимый размер матрицы!");
                    return;
                }
                int[,] matrix = new int[row,column];
                int[] vect = new int[column];
                int[,] matrixMultiply = new int[row, column];

                MatrixCreate(matrix , column, row);
                VectorCreate(vect, column);
                Multiply(matrix, vect, matrixMultiply,row ,column);
                
            }
            catch
            {
                MessageBox.Show("Ошибка! Нет данных!");
            }  
        }
        void MatrixCreate(int[,] matrix, int column, int row)
        {
                for(int i = 0; i < row; i++)
                {
                    for(int j = 0; j < column; j++)
                    {
                    matrix[i,j] = rnd.Next(-100, 100);
                    }
                }
                for(int z = 0; z < row; z++)
                {   
                    for (int x = 0; x < column; x++)
                    { 
                        skip = 4 - Convert.ToString(matrix[z, x]).Length;
                        MatrixBefore.Text +=string.Concat(Enumerable.Repeat(" ", skip)) + Convert.ToString(matrix[z,x])   + " ";
                    }
                    MatrixBefore.Text += "\n";
                }

        }

        
        void VectorCreate(int[] vect, int column)
        {
            Random rnd2 = new Random(); 
            for (int i = 0; i < column; i++)
            {
                vect[i] = rnd2.Next(-3, 3);
                CreatedVector.Text += Convert.ToString(vect[i]) + "\n";
            }
                
        }
        void Multiply(int[,] matrix, int[] vector, int[,] result, int row, int column)
        {
            
            for(int i = 0; i < row; i++)
            {
                int temp = 0;
                for(int j = 0; j < column; j++)
                {
                    result[i,j] = matrix[i,j] * vector[j];
                    temp = temp + result[i, j];
                    //skip = 4 - Convert.ToString(temp).Length;
                   
                }
                MatrixAfter.Text += string.Concat(Enumerable.Repeat(" ", skip)) + temp + " ";
                MatrixAfter.Text += "\n";
            }
        }
    }
}
