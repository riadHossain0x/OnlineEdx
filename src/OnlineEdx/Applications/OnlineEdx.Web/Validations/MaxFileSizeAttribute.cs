using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace OnlineEdx.Web.Validations
{
	public class MaxFileSizeAttribute : ValidationAttribute, IClientModelValidator
	{
		/// <summary>
		/// Gets the maximum acceptable size of the file in kilobytes.
		/// </summary>
		private int _maxFileSize;

		public MaxFileSizeAttribute(int maxFileSize)
		{
			_maxFileSize = maxFileSize;
		}

		protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
		{
			if (value is null)
				return ValidationResult.Success!;

			var file = value as IFormFile;
			var maxSize = _maxFileSize * 1000;
			if (file != null)
			{
				if (file.Length > maxSize)
				{
					return new ValidationResult(GetErrorMessage());
				}
			}

			return ValidationResult.Success!;
		}

		public string GetErrorMessage()
		{
			return $"Maximum allowed file size is {_maxFileSize} kilobytes.";
		}

		public void AddValidation(ClientModelValidationContext context)
		{
			MergeAttribute(context.Attributes, "data-val", "true");
			MergeAttribute(context.Attributes, "data-val-maxsize", GetErrorMessage());
			MergeAttribute(context.Attributes, "data-val-maxsize-size", _maxFileSize.ToString());
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
