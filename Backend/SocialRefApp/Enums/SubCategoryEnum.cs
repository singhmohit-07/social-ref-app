using System;
using System.Text.Json.Serialization;

namespace SocialRefApp.Enums
{

	[JsonConverter(typeof(JsonStringEnumConverter))]

	public enum SubCategoryEnum
	{
		UPSC,
		CTET,
		SUPERTET,
		DSSSB,
		KVS
	}
	
}

