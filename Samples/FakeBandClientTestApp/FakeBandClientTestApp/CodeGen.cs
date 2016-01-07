using FakeBandClientTestApp.ViewModels;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FakeBandClientTestApp
{
    public static class CodeGen
    {
        public static string GenerateXamlFromClass(ViewModelBase BindTarget)
        {
            var template1 = "<TextBlock x:Name=\"{0}Label\" FontSize=\"28\" Text=\"{{x:Bind {1}.{0}Label}}\"></TextBlock>";
            var template4 = "<TextBlock x:Name=\"{0}Label\" FontSize=\"28\" Text=\"{{x:Bind {1}.{0}Label}}\" RelativePanel.Below=\"{2}Label\"></TextBlock>";
            var template2 = "<TextBlock x:Name=\"{0}\" Text=\"{{x:Bind {1}.{0}, Mode=OneWay}}\" FontSize=\"28\" RelativePanel.RightOf=\"{0}Label\" RelativePanel.AlignVerticalCenterWith=\"{0}Label\"></TextBlock>";
            var template3 = "<TextBlock x:Name=\"{0}\" Text=\"{{x:Bind {1}.{0}, Mode=OneWay}}\" FontSize=\"28\" RelativePanel.RightOf=\"{0}Label\" RelativePanel.Below=\"{2}\" RelativePanel.AlignVerticalCenterWith=\"{0}Label\"></TextBlock>";

            var t = BindTarget.GetType();

            var props = t.GetRuntimeProperties();

            var sb = new StringBuilder();
            string prev = null;
            foreach (var prop in props)
            {
                if (prop.Name.EndsWith("Label"))
                    continue;

                if (string.IsNullOrEmpty(prev))
                {
                    sb.Append(string.Format(template1, prop.Name, t.Name));
                    sb.AppendLine();
                    sb.Append(string.Format(template2, prop.Name, t.Name));
                }
                else
                {
                    sb.Append(string.Format(template4, prop.Name, t.Name, prev));
                    sb.AppendLine();
                    sb.Append(string.Format(template3, prop.Name, t.Name, prev));
                }

                sb.AppendLine();
                prev = prop.Name;
            }
            return sb.ToString();
        }

        public static string GenerateViewModelCode(object instance)
        {
            var t = instance.GetType();
            var props = t.GetRuntimeProperties();

            string className = null;
            if (t.Name.StartsWith("Fake"))
                className = t.Name.Remove(0, "Fake".Length);
            if (className != null && className.EndsWith("Reading"))
                className = className.Remove(className.Length - "Reading".Length, "Reading".Length);

            string classHeadertemplate = @"public class {0}ViewModel : ViewModelBase";
            string openBraceTemplate = @"{";
            string closeBraceTemplate = @"}";
            string fieldTemplate = @"private {1} _{0};";
            string propTemplate = @"public {2} {0} {{ get {{ return _{1}; }} set {{ Set(ref _{1}, value); }} }}";
            string propLabelTemplate = @"public string {0}Label {{ get {{ return nameof({0}) + MainPage.LabelPostfix; }} }}";

            var sb = new StringBuilder();
            sb.AppendFormat(classHeadertemplate, className);
            sb.AppendLine();
            sb.Append(openBraceTemplate);

            foreach (var prop in props)
            {
                var fieldStr = prop.Name.First().ToString().ToLower() + string.Join("", prop.Name.Skip(1));
                var typeStr = prop.PropertyType.ToString();
                sb.AppendLine();
                sb.AppendFormat(fieldTemplate, fieldStr, typeStr);
                sb.AppendLine();
                sb.AppendFormat(propTemplate, prop.Name, fieldStr, typeStr);
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendFormat(propLabelTemplate, prop.Name);
                sb.AppendLine();
            }

            sb.Append(closeBraceTemplate);

            return sb.ToString();
        }

        //private FrameworkElement GenerateUI(object Instance, ViewModelBase BindTarget)
        //{
        //    //var sv = new ScrollViewer();

        //    //var rootGrid = new VariableSizedWrapGrid() { ItemWidth = 800 };
        //    //sv.Content = rootGrid;

        //    //var hc = new StackPanel() { Orientation = Orientation.Vertical };
        //    //hc.BorderBrush = new SolidColorBrush(Colors.AntiqueWhite);
        //    //hc.BorderThickness = new Thickness(2);

        //    var grid = new Grid();

        //    var t = Instance.GetType();
        //    //var ti = t.GetTypeInfo();
        //    //hc.Children.Add(new TextBlock { Text = ti.Name });

        //    var props = t.GetRuntimeProperties();

        //    int row = 0;
        //    foreach (var prop in props)
        //    {
        //        var sp = new StackPanel();
        //        var propVal = prop.GetValue(Instance);
        //        var enumerable = propVal as IEnumerable;
        //        if (enumerable != null)
        //        {
        //            propVal = "";
        //            foreach (var val in enumerable)
        //            {
        //                propVal += val.ToString();
        //            }
        //        }
        //        var propName = prop.Name;
        //        sp.Orientation = Orientation.Horizontal;
        //        sp.Children.Add(new TextBlock { Text = propName, Margin = new Thickness(4) });
        //        sp.Children.Add(new TextBlock { Text = propVal.ToString(), Margin = new Thickness(4) });

        //        grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

        //        sp.SetValue(Grid.RowProperty, row++);
        //        grid.Children.Add(sp);
        //    }
        //    grid.BorderBrush = new SolidColorBrush(Colors.AntiqueWhite);
        //    grid.BorderThickness = new Thickness(2);

        //    //hc.Children.Add(grid);
        //    //rootGrid.Children.Add(hc);

        //    return grid;
        //}

        //private FrameworkElement GenerateUI(params object[] instances)
        //{
        //    var sv = new ScrollViewer();

        //    var rootGrid = new VariableSizedWrapGrid() { ItemWidth = 800 };
        //    sv.Content = rootGrid;

        //    foreach (var instance in instances)
        //    {
        //        var hc = new StackPanel() { Orientation = Orientation.Vertical };
        //        hc.BorderBrush = new SolidColorBrush(Colors.AntiqueWhite);
        //        hc.BorderThickness = new Thickness(2);

        //        var grid = new Grid();

        //        var t = instance.GetType();
        //        var ti = t.GetTypeInfo();
        //        hc.Children.Add(new TextBlock { Text = ti.Name });

        //        var props = t.GetRuntimeProperties();

        //        int row = 0;
        //        foreach (var prop in props)
        //        {
        //            var sp = new StackPanel();
        //            var propVal = prop.GetValue(instance);
        //            var enumerable = propVal as IEnumerable;
        //            if (enumerable != null)
        //            {
        //                propVal = "";
        //                foreach (var val in enumerable)
        //                {
        //                    propVal += val.ToString();
        //                }
        //            }
        //            var propName = prop.Name;
        //            sp.Orientation = Orientation.Horizontal;
        //            sp.Children.Add(new TextBlock { Text = propName, Margin = new Thickness(4) });
        //            sp.Children.Add(new TextBlock { Text = propVal.ToString(), Margin = new Thickness(4) });

        //            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

        //            sp.SetValue(Grid.RowProperty, row++);
        //            grid.Children.Add(sp);
        //        }
        //        grid.BorderBrush = new SolidColorBrush(Colors.AntiqueWhite);
        //        grid.BorderThickness = new Thickness(2);

        //        hc.Children.Add(grid);
        //        rootGrid.Children.Add(hc);
        //    }

        //    return sv;
        //}
    }
}
