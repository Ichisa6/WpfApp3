using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WpfApp3.Compnents;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        Dictionary<int, List<int>> dictA = new Dictionary<int, List<int>>(10);
        Dictionary<int, List<int>> dictB = new Dictionary<int, List<int>>(10);
        Dictionary<int, List<int>> dictC = new Dictionary<int, List<int>>(10);
        Dictionary<int, List<string>> numGroup = new Dictionary<int, List<string>>(10);

        public MainWindow()
        {
            InitializeComponent();
            var allTypes = App.DB.CodeAN13.ToList();
            CBCode.ItemsSource = allTypes;
            FillDict();
            Load("0000000000000");
        }
        private Rectangle copyRec(Rectangle rec)
        {
            return new Rectangle()
            {
                Height = Math.Floor(rec.Height),
                Width= Math.Floor(rec.Width),
                Margin = new Thickness(rec.Margin.Left + rec.Width, 10, 0, 0),
                Fill =System.Windows.Media.Brushes.Black,
                SnapsToDevicePixels = true
            };
        }
        public void FillDict()
        {
            dictA.Add(0, new List<int> { 3, 2, 1, 1 });
            dictA.Add(1, new List<int> { 2, 2, 2, 1 });
            dictA.Add(2, new List<int> { 2, 1, 2, 2 });
            dictA.Add(3, new List<int> { 1, 4, 1, 1 });
            dictA.Add(4, new List<int> { 1, 1, 3, 2 }) ;
            dictA.Add(5, new List<int> { 1, 2, 3, 1 });
            dictA.Add(6, new List<int> { 1, 1, 1, 4 });
            dictA.Add(7, new List<int> { 1, 3, 1, 2 });
            dictA.Add(8, new List<int> { 1, 2, 1, 3 }); 
            dictA.Add(9, new List<int> { 3, 1, 1, 2 }); 

            dictB.Add(0, new List<int> { 1, 1, 2, 3});
            dictB.Add(1, new List<int> { 1, 2, 2, 2}); 
            dictB.Add(2, new List<int> { 2, 2, 1, 2 });
            dictB.Add(3, new List<int> { 1, 1, 4, 1 });
            dictB.Add(4, new List<int>  { 2, 3, 1, 1 });
            dictB.Add(5, new List<int> { 1, 3, 2, 1 });
            dictB.Add(6, new List<int> { 4, 1, 1, 1 });
            dictB.Add(7, new List<int> { 2, 1, 3, 1 });
            dictB.Add(8, new List<int> { 3, 1, 2, 1 });
            dictB.Add(9, new List<int> { 2, 1, 1, 3});

            dictC.Add(0, new List<int> { 3, 2, 1, 1 });
            dictC.Add(1, new List<int> { 2, 2, 2, 1 });
            dictC.Add(2, new List<int> { 2, 1, 2, 2 });
            dictC.Add(3, new List<int> { 1, 4, 1, 1 });
            dictC.Add(4, new List<int> { 1, 1, 3, 2 });
            dictC.Add(5, new List<int> { 1, 2, 3, 1 });
            dictC.Add(6, new List<int> { 1, 1, 1, 4 });
            dictC.Add(7, new List<int> { 1, 3, 1, 2 });
            dictC.Add(8, new List<int> { 1, 2, 1, 3 });
            dictC.Add(9, new List<int> { 3, 1, 1, 2 });

            numGroup.Add(0, new List<string> { "A", "A", "A", "A", "A", "A" });
            numGroup.Add(1, new List<string> { "A", "A", "B", "A", "B", "B" });
            numGroup.Add(2, new List<string> { "A", "A", "B", "B", "A", "B" });
            numGroup.Add(3, new List<string> { "A", "A", "B", "B", "B", "A" });
            numGroup.Add(4, new List<string> { "A", "B", "A", "A", "B", "B" });
            numGroup.Add(5, new List<string> { "A", "B", "B", "A", "A", "B" });
            numGroup.Add(6, new List<string> { "A", "B", "B", "B", "A", "A" });
            numGroup.Add(7, new List<string> { "A", "B", "A", "B", "A", "B" });
            numGroup.Add(8, new List<string> { "A", "B", "A", "B", "B", "A" });
            numGroup.Add(9, new List<string> { "A", "B", "B", "A", "B", "A" });


        }

public void Load(string num)
{
    borcodeCan.Children.RemoveRange(0, borcodeCan.Children.Count - 1);
    char[] nums = num.Replace(" ", "").Replace(",", "").ToArray<char>();
    List<string> numGroupNum = numGroup[Convert.ToInt32(nums[0]) - 48];
    Rectangle rect = new Rectangle()
    {
        Height = 222.0,
        Width = 4.0,
        Margin = new Thickness(30, 10, 0, 0),
        Fill = System.Windows.Media.Brushes.Black,
        SnapsToDevicePixels = true
    };
    Rectangle rect2 = new Rectangle()
    {
        Height = 222.0,
        Width = 2.0,
        Margin = new Thickness(33, 10, 0, 0),
        Fill = System.Windows.Media.Brushes.White,
        SnapsToDevicePixels = true
    };
    Rectangle rect1_2 = new Rectangle()
    {
        Height = 222.0,
        Width = 4.0,
        Margin = new Thickness(36, 10, 0, 0),
        Fill = System.Windows.Media.Brushes.Black,
        SnapsToDevicePixels = true
    };
    Label lb1 = new Label()
    {
        Content = nums[0],
        FontSize = 24,
        FontWeight = FontWeights.Bold,
        Margin = new Thickness(8, 207, 0, 0)
    };
    borcodeCan.Children.Add(lb1);
    borcodeCan.Children.Add(rect);
    borcodeCan.Children.Add(rect2);
    borcodeCan.Children.Add(rect1_2);
            Rectangle localRec = rect1_2;
            for (int i = 0; i < 6; i ++)
            {
                Rectangle rec1 = new Rectangle()
                {
                    Height = 207.0,
                    Width = (numGroupNum[i] == "A") ? 3.0 * dictA[Convert.ToInt32(nums [i + 1]) - 48][0] : 3.0 * dictB[Convert.ToInt32(nums[i + 1]) - 48][0],
                    Margin = new Thickness(localRec.Margin.Left + localRec.Width, 10, 0, 0),
                    Fill = System.Windows.Media.Brushes.White,
                    SnapsToDevicePixels = true
                };
                Rectangle rec2 = new Rectangle()
                {
                    Height = 207.0,
                    Width = (numGroupNum[i] == "A") ? 3.0 * dictA[Convert.ToInt32(nums[i + 1]) - 48][1] : 3.0 * dictB[Convert.ToInt32(nums[i + 1]) - 48][1],
                    Margin = new Thickness(rec1.Margin.Left + rec1.Width, 10, 0, 0),
                    Fill = System.Windows.Media.Brushes.Black,
                    SnapsToDevicePixels = true
                };
                Rectangle rec3 = new Rectangle()
                {
                    Height = 207.0,
                    Width = (numGroupNum[i] == "A") ? 3.0 * dictA[Convert.ToInt32(nums[i + 1]) - 48][2] : 3.0 * dictB[Convert.ToInt32(nums[i + 1]) - 48][2],
                    Margin = new Thickness(rec2.Margin.Left + rec2.Width, 10, 0, 0),
                    Fill = System.Windows.Media.Brushes.White,
                    SnapsToDevicePixels = true
                };
                Rectangle rec4 = new Rectangle()
                {
                    Height = 207.0,
                    Width = (numGroupNum[i] == "A") ? 3.0 * dictA[Convert.ToInt32(nums[i + 1]) - 48][3] : 3.0 * dictB[Convert.ToInt32(nums[i + 1]) - 48][3],
                    Margin = new Thickness(rec3.Margin.Left + rec3.Width, 10, 0, 0),
                    Fill = System.Windows.Media.Brushes.Black,
                    SnapsToDevicePixels = true
                };
                Label lbl = new Label()
                {
                    Content = nums[i + 1],
                    FontSize = 24,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(rec1.Margin.Left, 207, 0, 0),
                };
                localRec = rec4;
                borcodeCan.Children.Add(lbl);
                borcodeCan.Children.Add(rec1);
                borcodeCan.Children.Add(rec2);
                borcodeCan.Children.Add(rec3);
                borcodeCan.Children.Add(rec4);

            }
            Rectangle rect3 = copyRec(localRec);
            rect3.Margin = new Thickness(rect3.Margin.Left + 6.0, 10, 0, 0);
            rect3.Width = 4.0;
            rect3.Height = 222.0;
            Rectangle rect4 = copyRec(rect3);
            rect4.Margin = new Thickness(rect3.Margin.Left + 3.0, 10, 0, 0);
            rect4.Width = 4.0;
            borcodeCan.Children.Add(rect3);
            borcodeCan.Children.Add(rect4);
            localRec = copyRec(rect4);
            for (int i = 7; i < 13; i++)
            {
                Rectangle rec1 = new Rectangle()
                {
                    Height = 207.0,
                    Width = 3.0 * dictC[Convert.ToInt32(nums[i]) - 48][0],
                    Margin = new Thickness(localRec.Margin.Left + localRec.Width, 10, 0, 0),
                    Fill = System.Windows.Media.Brushes.Black,
                    SnapsToDevicePixels = true
                };
                Rectangle rec2 = new Rectangle()
                {
                    Height = 207.0,
                    Width = 3.0 * dictC[Convert.ToInt32(nums[i]) - 48][1],
                    Margin = new Thickness(rec1.Margin.Left + rec1.Width, 10, 0, 0),
                    Fill = System.Windows.Media.Brushes.White,
                    SnapsToDevicePixels = true
                };
                Rectangle rec3 = new Rectangle()
                {
                    Height = 207.0,
                    Width = 3.0 * dictC[Convert.ToInt32(nums[i]) - 48][2],
                    Margin = new Thickness(rec2.Margin.Left + rec2.Width, 10, 0, 0),
                    Fill = System.Windows.Media.Brushes.Black,
                    SnapsToDevicePixels = true
                };
                Rectangle rec4 = new Rectangle()
                {
                    Height = 207.0,
                    Width = 3.0 * dictC[Convert.ToInt32(nums[i]) - 48][3],
                    Margin = new Thickness(rec3.Margin.Left + rec3.Width, 10, 0, 0),
                    Fill = System.Windows.Media.Brushes.White,
                    SnapsToDevicePixels = true
                };
                Label lbl = new Label()
                {
                    Content = nums[i],
                    FontSize = 24,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(rec1.Margin.Left, 207, 0, 0),
                };
                localRec = rec4;
                borcodeCan.Children.Add(lbl);
                borcodeCan.Children.Add(rec1);
                borcodeCan.Children.Add(rec2);
                borcodeCan.Children.Add(rec3);
                borcodeCan.Children.Add(rec4);
                
            }
            Rectangle rect5 = copyRec(localRec); 
            rect5.Width = 4.0;
            rect5.Height = 222.0;
            Rectangle rect6 = copyRec(rect5);
            rect3.Margin = new Thickness(rect3.Margin.Left + 3.0, 10, 0, 0);
            rect3.Width = 4.0;
            borcodeCan.Children.Add(rect5);
            borcodeCan.Children.Add(rect6);

        }
    private void txtBox_TextChanged(object sender, TextChangedEventArgs e)
  {
    try
    {
        Load(txtBox.Text);
    }
    catch
    {

    }
}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show($"{(CBCode.SelectedValue)}");
           
        }
        private void txtBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            if (txtBox.Text.Length == 1 && e.Key == Key.Back)
            {
                txtBox.Text = String.Empty;
                Load("0000000000000");
            }
        }

        private void txtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
                e.Handled = true;
        }



        private void CBBarcode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            txtBox.Text = (CBCode.SelectedItem as CodeAN13).Name;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            char[] Buffer = txtBox.Text.ToCharArray();
            int sumH = 0;
            int sumOdd = 0;
            int result = 0;

            if (txtBox.Text.Length < 13)
            {
                MessageBox.Show("Выберите штрихкод или напишите свой");
                return;
            }

            for (int i = 0; i < txtBox.Text.Length - 1; i += 2)
            {
                sumH += (int)Char.GetNumericValue(Buffer[i + 1]);
                sumOdd += (int)Char.GetNumericValue(Buffer[i]);
            }
            result = 10 - ((sumH * 3 + sumOdd) % 10);

            if (result == (int)Char.GetNumericValue(Buffer.Last()))
                MessageBox.Show($"Код верен", "Ответ", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show($"Код неверен", "Ответ", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}


