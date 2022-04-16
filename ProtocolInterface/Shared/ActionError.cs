using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	public struct ActionError
	{
		public int ErrorNumber { get; private set; }
		public string ErrorMessage { get; private set; }

		public bool HasError { get { return !string.IsNullOrEmpty(ErrorMessage); } }

		public ActionError(string errorMessage, int errorNumber = 0)
		{
			ErrorMessage = errorMessage;
			ErrorNumber = errorNumber;
		}

		public override string ToString()
		{
			if (HasError)
				if (ErrorNumber != 0)
					return $"{ErrorMessage}";
				else
					return $"{ErrorNumber.ToString()}: {ErrorMessage}";
			else
				return "";
		}
	}
}
