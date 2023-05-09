namespace EventDemo
{
    public class CheckBox
    {
        public String text { get; set; }
        private bool _checked;

        public bool check
        {
            get { return _checked; }
            set
            {
                if (_checked != value)
                {
                    if (CheckChange != null)
                    {
                        CheckChange(text, value);

                    }
                }
                _checked = value;
            }
        }


        public CheckBox()
        {
        }

        //Tạo sự kiện check-change
        public delegate void handle(String text, bool check);
        public event handle CheckChange;


    }
}