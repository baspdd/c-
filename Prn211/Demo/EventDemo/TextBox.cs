using static System.Net.Mime.MediaTypeNames;

namespace EventDemo
{
    public class TextBox
    {
        private String _text;

        public String Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    if (textChange != null)
                    {
                        textChange();

                    }
                }
                _text = value;
            }
        }

        public delegate void handle();
        public event handle textChange;
    }
}