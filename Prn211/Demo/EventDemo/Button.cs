namespace EventDemo
{
    public class Button
    {
        public String caption { get; set; }

        public Button()
        {
        }
        
        public Button(string caption)
        {
            this.caption = caption;
        }

        // tạo sự kiện nhấn nút cho button
        public delegate void handle();
        public event handle onClick;

        // khi nào sự kiện onClick được kích hoạt ??
        // khi nhấn nút
        // mô phỏng thao tác nhấn nút

        public void click()
        {
            //check nút được gán sự kiện
            if (onClick!=null)
            {
                onClick();
            }
        }
    }
}