using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Pages
{
    public class UpLoadFilesModel : PageModel
    {
        private IHostEnvironment _evironment;
        public UpLoadFilesModel(IHostEnvironment evironment)
        {
            _evironment = evironment;
        }

        [Required(ErrorMessage = "Please chose a file")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,gif")]
        [Display(Name = "Choose files to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }
        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            if (FileUploads != null)
            {
                foreach (var fileUpload in FileUploads)
                {
                    var file = Path.Combine(_evironment.ContentRootPath, "Images");

                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await fileUpload.CopyToAsync(fileStream);
                    };

                }
            }
        }
    }
}
