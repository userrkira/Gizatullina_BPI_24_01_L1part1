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



namespace Gizatullina_BPI_24_01_L1part1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string surname = SurnameTextBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(surname))
                {
                    throw new Exception("Введите фамилию.");
                }

                foreach (char symbol in surname)
                {
                    if (!char.IsLetter(symbol) && symbol != '-' && symbol != ' ')
                    {
                        throw new Exception("Фамилия должна содержать только буквы!!!");
                    }
                }

                if (!decimal.TryParse(SalaryTextBox.Text, out decimal salary))
                {
                    throw new Exception("Оклад должен быть числом!!!");
                }

                if (salary <= 0)
                {
                    throw new Exception("Оклад должен быть больше нуля!!!");
                }

                if (!int.TryParse(YearTextBox.Text, out int year))
                {
                    throw new Exception("Год поступления должен быть целым числом!!!");
                }

                int currentYear = DateTime.Now.Year;

                if (year < 1900 || year > currentYear)
                {
                    if (year < 0)
                    {
                        throw new Exception("Год не может быть отрицательным.");
                    }
                    throw new Exception(
                        $"Год должен быть от 1900 до {currentYear}."
                    );
                }

                // cоздаём объект работника
                worker worker = new worker (
                    surname,
                    salary,
                    year
                );

                int experience = worker.CalculateExperience();
                int days = worker.CalculateDays();

                ResultTextBlock.Text =
                    $"Фамилия: {worker.Surname}\n" +
                    $"Оклад($): {worker.Salary:N2} руб.\n" +
                    $"Год поступления: {worker.YearOfEmployment}\n\n" +
                    $"Стаж работы: {experience} лет\n" +
                    $"Прошло дней: {days}";

                ResultBorder.Visibility = Visibility.Visible;


                SizeToContent = SizeToContent.Height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка ввода",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
            }
        }
    }
}