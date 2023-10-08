using System.ComponentModel.DataAnnotations;

namespace Asp_Net_Core_ETicaret.Models
{
	public class EditUserViewModel
	{
		[Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz!!!")]
		[MinLength(3, ErrorMessage = "Bu Alana 3 Karakterden Az Girmeyiniz!!!")]
		public string NameSurname { get; set; }

		public DateTime CreateDate { get; set; }
		public bool Locked { get; set; }


		[MinLength(3, ErrorMessage = "Bu Alana 3 Karakterden Az Girmeyiniz!!!")]
		public string Role { get; set; }

		public string ProfileImageFileName { get; set; }
	}
}
