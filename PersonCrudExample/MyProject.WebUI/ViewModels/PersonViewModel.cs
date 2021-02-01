using System;
using System.ComponentModel.DataAnnotations;
using MyProject.Entity;


namespace MyProject.WebUI.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Isim")]
        [Required(ErrorMessage = "Isim alani zorunludur.")]
        public String FirstName { get; set; } 

        [Display(Name = "Soyisim")]
        [Required(ErrorMessage = "Soyisim alani zorunludur.")]
        public String LastName { get; set; }

        [Display(Name = "Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet alanı zorunludur.")]
        public Gender Gender { get; set; }

        [Display(Name = "Dogum Tarihi")]
        [Required(ErrorMessage = "Dogum Tarihi alani zorunludur.")]
        public DateTime? BirthDate { get; set; }
    }
}