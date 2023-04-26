namespace WinFormsCustomControls
{
    internal class MyButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.FillEllipse(Brushes.DodgerBlue, ClientRectangle);
        }

    }
}
