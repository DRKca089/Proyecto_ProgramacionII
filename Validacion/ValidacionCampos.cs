using System.Windows.Forms;

public static class ValidacionCampos
{
    public static bool EstanLlenos(params Control[] controles)
    {
        foreach (var control in controles)
        {
            if (control is TextBox t && string.IsNullOrWhiteSpace(t.Text))
                return false;
            if (control is ComboBox c && string.IsNullOrWhiteSpace(c.Text))
                return false;
        }
        return true;
    }
}