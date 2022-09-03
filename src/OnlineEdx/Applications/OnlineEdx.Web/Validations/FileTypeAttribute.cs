using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OnlineEdx.Web.Validations
{
	public class FileTypeAttribute : ValidationAttribute, IClientModelValidator
	{
		/// <summary>
		/// Gets the acceptable extensions of the file.
		/// </summary>
		private readonly string[] _extensions;

		public FileTypeAttribute(string[] extensions)
		{
			_extensions = extensions;
		}

		protected override ValidationResult IsValid(object? value, ValidationContext context)
		{
			if (value is null)
				return ValidationResult.Success!;

			var file = value as IFormFile;
			if (file != null)
			{
				var extension = Path.GetExtension(file.FileName);
				if (_extensions.Contains(extension.ToLower()))
				{
					return ValidationResult.Success!;
				}
			}

			return new ValidationResult(GetErrorMessage());
		}

		public string GetErrorMessage()
		{
			return $"Please Enter valid image ({string.Join(",", _extensions)})";
		}

		public void AddValidation(ClientModelValidationContext context)
		{
			MergeAttribute(context.Attributes, "data-val", "true");
			MergeAttribute(context.Attributes, "data-val-filetype", GetErrorMessage());
			MergeAttribute(context.Attributes, "data-val-filetype-types", string.Join(",", _extensions));
		}

		private static bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
		{
			if (attributes.ContainsKey(key))
			{
				return false;
			}

			attributes.Add(key, value);
			return true;
		}
	}
}
